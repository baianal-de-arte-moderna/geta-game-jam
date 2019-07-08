using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamDoorBlinkScript : MonoBehaviour
{
    MeshRenderer render;
    Color targetColor;
    // Start is called before the first frame update
    void Start()
    {
        render = (MeshRenderer)GetComponent<Renderer>();
        targetColor = Color.clear;
        Invoke("Flash", 3f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        render.material.SetColor("_BaseColor", targetColor);
        targetColor = Color.Lerp(targetColor, Color.clear, 0.02f);
    }

    void Flash()
    {
        targetColor = Color.white;
        targetColor.a = 0.5f;
        Invoke("Flash", 5f);
    }
}
