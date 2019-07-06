/* vim: set ts=4 sts=4 sw=4 expandtab: */
using UnityEngine;

public class HaltBehaviour : BaseBehaviour {

    private Rigidbody rigidbody;

    public override bool InterruptChain()
    {
        return true;
    }

    public override bool IsActive()
    {
        return true;
    }

    protected override void Start() {
        base.Start();
        rigidbody = GetComponent<Rigidbody>();
    }

    public override void Iterate()
    {
        rigidbody.velocity = Vector3.Dot(rigidbody.velocity, rigidbody.transform.up) * rigidbody.transform.up;
    }
}

