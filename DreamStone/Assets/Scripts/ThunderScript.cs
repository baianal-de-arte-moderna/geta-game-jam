using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderScript : MonoBehaviour
{
    new Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        light.color = Color.Lerp(
            light.color,
            Color.clear,
            0.2f
        );
    }

    public void Flash(float delay)
    {
        Invoke("Flash", delay);
    }

    public void Flash()
    {
        light.color = Color.white;
    }
}
