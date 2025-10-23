using UnityEngine;
using UnityEngine.InputSystem;

public class FingerSegment : MonoBehaviour
{
    [Header("References")]
    public Transform baseTransform;      // Finger_Base object

    [Header("Rotation Settings")]
    public float rotationSpeed = 90f;    // degrees per second
    public float minAngle = -90f;
    public float maxAngle = 0f;

    private float currentAngle = 0f;
    private Vector3 pivot;               // world-space pivot
    private Vector3 initialOffset;       // original offset relative to pivot
    private Quaternion initialRotation;  // starting rotation

    void Start()
    {
        float halfBase = baseTransform.localScale.x / 2f;

        pivot = baseTransform.position + baseTransform.right * halfBase;

        initialOffset = transform.position - pivot;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        float input = 0f;
        if (Keyboard.current.aKey.isPressed) input = -1f;
        if (Keyboard.current.dKey.isPressed) input = 1f;

        currentAngle += input * rotationSpeed * Time.deltaTime;
        currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);

        Quaternion delta = Quaternion.AngleAxis(currentAngle, baseTransform.forward);
        Quaternion newRot = delta * initialRotation;

        Vector3 rotatedOffset = delta * initialOffset;
        transform.position = pivot + rotatedOffset;
        transform.rotation = newRot;
    }
}