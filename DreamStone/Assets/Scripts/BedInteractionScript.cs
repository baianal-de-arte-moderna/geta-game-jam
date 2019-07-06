using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedInteractionScript : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bed"))
        {
            var bed = other.GetComponent<BedBehaviourScript>();
            bed?.Select();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bed"))
        {
            var bed = other.GetComponent<BedBehaviourScript>();
            bed?.Unselect();
        }
    }
}
