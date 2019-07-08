using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoWobbleScript : MonoBehaviour
{
    public float intensity;
    float rand;
    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = Random.insideUnitSphere;
        rand = Random.Range(2f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        rand -= Time.deltaTime;
        if (rand < 0)
        {
            rand = Random.Range(2f, 4f);
            direction = Random.insideUnitSphere;
        }
        transform.Rotate(direction * intensity * Time.deltaTime);
        transform.Translate(direction * intensity / 100f * Time.deltaTime);
    }
}
