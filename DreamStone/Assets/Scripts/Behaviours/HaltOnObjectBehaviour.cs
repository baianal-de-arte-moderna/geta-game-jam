/* vim: set ts=4 sts=4 sw=4 expandtab: */
using UnityEngine;

public class HaltOnObjectBehaviour : BaseBehaviour {

    [SerializeField]
    private string haltedOnObjectTag;

    private new Rigidbody rigidbody;
    private Vector3 startVelocity;

    protected void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    public override bool IsActive() {
        bool isActive = GameObject.FindWithTag(haltedOnObjectTag) != null;

        if (!isActive && startVelocity != Vector3.zero) {
            rigidbody.velocity = startVelocity;
            startVelocity = Vector3.zero;
        }

        return isActive;
    }

    public override bool InterruptChain() {
        return true;
    }

    public override void Iterate() {
        if (rigidbody.velocity != Vector3.zero) {
            startVelocity = rigidbody.velocity;
            rigidbody.velocity = Vector3.zero;
        }
    }
}

