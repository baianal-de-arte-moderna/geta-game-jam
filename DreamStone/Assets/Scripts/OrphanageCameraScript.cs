using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrphanageCameraScript : MonoBehaviour
{
    public float minAngle = 3f;
    public float maxAngle = 30f;
    public float speed = 10f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.mousePosition.x >= Screen.width * 0.9 && transform.localRotation.eulerAngles.y < maxAngle)
        {
            transform.Rotate(Vector3.up * speed * (Input.mousePosition.x / Screen.width), Space.World);
        }
        if (Input.mousePosition.x <= Screen.width * 0.1 && transform.localRotation.eulerAngles.y > minAngle)
        {
            transform.Rotate(Vector3.down * speed * ((Screen.width - Input.mousePosition.x) / Screen.width), Space.World);
        }
    }
}
