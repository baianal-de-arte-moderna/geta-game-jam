/* vim: set ts=4 sts=4 sw=4 expandtab: */
using UnityEngine;

public class HaltBehaviour : BaseBehaviour {

    private new Rigidbody rigidbody;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    public override bool IsActive() {
        return true;
    }

    public override bool InterruptChain() {
        return true;
    }

    public override void Iterate() {
        rigidbody.velocity = Vector3.zero;
    }
}

