using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWobbleScript : MonoBehaviour
{
    public float wobbleIntensity;
    void Update()
    {
        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            Random.insideUnitSphere,
            wobbleIntensity / 10f
            );
    }
}
