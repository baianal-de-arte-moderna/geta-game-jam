using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select()
    {
        transform.localScale *= 1.2f;
    }

    public void Unselect()
    {
        transform.localScale /= 1.2f;
    }
}
