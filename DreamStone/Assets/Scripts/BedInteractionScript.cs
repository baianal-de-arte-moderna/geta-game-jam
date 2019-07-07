using UnityEngine;

public class BedInteractionScript : MonoBehaviour {
    private BedBehaviourScript currentBed;

    private void Update() {
        if (Input.GetMouseButtonUp(0)) {
            currentBed?.Interact();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Bed")) {
            currentBed?.Unselect();
            currentBed = other.GetComponent<BedBehaviourScript>();
            currentBed?.Select();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Bed")) {
            currentBed?.Unselect();
            currentBed = null;
        }
    }
}
