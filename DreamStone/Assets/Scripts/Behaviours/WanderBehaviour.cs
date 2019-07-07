/* vim: set ts=4 sts=4 sw=4 expandtab: */
using UnityEngine;

public class WanderBehaviour : BaseBehaviour {

    [SerializeField]
    private int maxWanders;

    private new Rigidbody rigidbody;
    private int wanderCount;
    private float lastActionTime;
    private Vector3 force;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        lastActionTime = 0f;
    }

    public override bool IsActive() {
        bool isActive = (wanderCount < maxWanders) || (TimeSinceLastAction() > 5);
        if (!isActive) {
            rigidbody.AddForce(-force);
            force = Vector3.zero;
        }
        return isActive;
    }

    public override bool InterruptChain() {
        return true;
    }

    public override void Iterate() {
        if (wanderCount >= maxWanders) {
            wanderCount = 0;
        }

        if (TimeSinceLastAction() > 1) {
            if (force != Vector3.zero) {
                rigidbody.AddForce(-force);
                force = Vector3.zero;
            } else {
                Vector3 newPoint = RandomPointOnPlane(transform.position, transform.up, 1.0f);
                transform.LookAt(newPoint);

                force = transform.forward * 25f;
                rigidbody.AddForce(force);

                wanderCount++;
            }

            lastActionTime = Time.time;
        }
    }

    private float TimeSinceLastAction() {
        return Time.time - lastActionTime;
    }

    private Vector3 RandomPointOnPlane(Vector3 position, Vector3 normal, float radius) {
        Vector3 randomPoint = Vector3.Cross(Random.insideUnitSphere, normal);
        randomPoint *= radius;
        randomPoint += position;
        return randomPoint;
    }
}
