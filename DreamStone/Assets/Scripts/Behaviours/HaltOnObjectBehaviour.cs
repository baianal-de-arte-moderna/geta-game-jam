/* vim: set ts=4 sts=4 sw=4 expandtab: */
using UnityEngine;

public class HaltOnObjectBehaviour : BaseBehaviour {

    [SerializeField]
    private string haltedOnObjectTag;

    private new Rigidbody rigidbody;
    private bool isActive;

    protected void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    public override bool IsActive() {
        return isActive;
    }

    public override bool InterruptChain() {
        return true;
    }

    public override void Iterate() {
        rigidbody.velocity = Vector3.zero;
        isActive = false;
    }

    private void OnCollisionStay(Collision collision) {
        if (collision.collider.CompareTag(haltedOnObjectTag)) {
            isActive = true;
        }
    }
}

