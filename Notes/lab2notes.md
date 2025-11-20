# Notes lab 2 vr

- work on completing the code without rotations
- generating the ellipsoids
- go one by one
    - ellipsoids
    - when that is working, do the other one
    - disable ellipsoids and work on the other one
- generate only 3 images
    - 0, 30, 60


```C#
T = 1
K = 0, 0, 0

K += ci * T * ai
T *= (1-ai) // choose an epsilon value (very small) and when we are below that, set to 0


```