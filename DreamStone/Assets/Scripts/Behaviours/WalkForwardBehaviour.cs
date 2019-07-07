using UnityEngine;

public class WalkForwardBehaviour : BaseBehaviour {

    [SerializeField]
    private float walkForce;

    private new Rigidbody rigidbody;
    private Vector3 startPosition;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    public override bool IsActive() {
        return true;
    }

    public override bool InterruptChain() {
        return true;
    }

    public override void Iterate() {
        if (rigidbody.velocity == Vector3.zero) {
            rigidbody.AddForce(transform.forward * walkForce);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Respawn")) {
            transform.position = startPosition;
        }
    }
}
