/* vim: set ts=4 sts=4 sw=4 expandtab: */
using UnityEngine;

public class WanderBehaviour : BaseBehaviour
{
    [SerializeField] private int maxWanders;

    private Rigidbody rigidbody;
    private int wanderCount;
    private float lastActionTime;

    protected override void Start()
    {
        base.Start();
        this.rigidbody = GetComponent<Rigidbody>();
        this.lastActionTime = 0f;
    }

    public override bool InterruptChain()
    {
        return true;
    }

    public override bool IsActive()
    {
        return (wanderCount < maxWanders) || (TimeSinceLastAction() > 5);
    }

    public override void Iterate()
    {
        if (wanderCount >= maxWanders)
        {
            wanderCount = 0;
        }

        if (TimeSinceLastAction() > 1)
        {
            if (rigidbody.velocity.magnitude > 0.01f)
            {
                rigidbody.velocity = Vector3.zero;
            }
            else if (wanderCount < maxWanders)
            {
                Vector3 newPoint = RandomPointOnPlane(rigidbody.transform.position,
                    rigidbody.transform.up, 1.0f);
                Vector3 delta = newPoint - rigidbody.transform.position;

                delta.Normalize();
                this.transform.LookAt(newPoint);
                rigidbody.AddForce(delta * 25f);
                wanderCount++;
            }
            lastActionTime = Time.time;
        }
    }

    float TimeSinceLastAction()
    {
        return Time.time - lastActionTime;
    }

    private Vector3 RandomPointOnPlane(Vector3 position, Vector3 normal, float radius)
    {
        Vector3 randomPoint;
        do
        {
            randomPoint = Vector3.Cross(Random.insideUnitSphere, normal);
        } while (randomPoint == Vector3.zero);

        randomPoint.Normalize();
        randomPoint *= radius;
        randomPoint += position;

        return randomPoint;
    }
}
