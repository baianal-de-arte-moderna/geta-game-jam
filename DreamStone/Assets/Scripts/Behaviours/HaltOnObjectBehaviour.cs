/* vim: set ts=4 sts=4 sw=4 expandtab: */
using UnityEngine;

public class HaltOnObjectBehaviour : BaseBehaviour
{
    [SerializeField]
    private string haltedOnObjectTag;

    private new Rigidbody rigidbody;

    protected void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    public override bool InterruptChain()
    {
        return true;
    }

    public override bool IsActive()
    {
        return GameObject.FindWithTag(haltedOnObjectTag) != null;
    }

    public override void Iterate()
    {
        rigidbody.velocity = Vector3.Dot(rigidbody.velocity, rigidbody.transform.up) * rigidbody.transform.up;
    }
}

