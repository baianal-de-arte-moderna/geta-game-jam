using UnityEngine;

public class JumpOverObjectBehaviour : BaseBehaviour {

    [SerializeField]
    private string jumpedOverObjectTag;

    [SerializeField]
    private float walkForce;

    [SerializeField]
    private float jumpForceUp;

    [SerializeField]
    private float jumpForceForward;

    private enum State {
        Idle,
        WalkingTowards,
        Jumping,
        WalkingAway,
    }

    private new Rigidbody rigidbody;
    private Vector3 initialPosition;
    private State state;
    private Vector3 rotationVector;
    private Vector3 force;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }

    public override bool IsActive() {
        bool isActive = GameObject.FindWithTag(jumpedOverObjectTag) != null;
        if (!isActive) {
            SetState(State.Idle);
        }
        return isActive;
    }

    public override bool InterruptChain() {
        return true;
    }

    public override void Iterate() {
        if (state == State.Idle) {
            SetState(State.WalkingTowards);
        }
    }

    private void OnTriggerStay(Collider other) {
        if (state == State.WalkingTowards && other.CompareTag(jumpedOverObjectTag)) {
            SetState(State.Jumping);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (state == State.Jumping) {
            SetState(State.WalkingAway);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Respawn")) {
            transform.position = initialPosition;
            rigidbody.velocity = Vector3.zero;
            state = State.Idle;
            force = Vector3.zero;
        }
    }

    private void SetState(State newState) {
        //Debug.Log($"Change state from {state} to {newState}");

        this.state = newState;
        switch (state) {
            case State.Idle:
                rigidbody.AddForce(-force);
                force = Vector3.zero;
                break;
            case State.WalkingTowards: {
                    GameObject jumpedOverObject = GameObject.FindWithTag(jumpedOverObjectTag);
                    rotationVector.Set(jumpedOverObject.transform.position.x, transform.position.y, jumpedOverObject.transform.position.z);
                    transform.LookAt(rotationVector);

                    rigidbody.AddForce(-force);
                    force = transform.forward * walkForce;
                    rigidbody.AddForce(force);
                    break;
                }
            case State.Jumping:
                rigidbody.AddForce(-force);
                force = transform.forward * jumpForceForward + transform.up * jumpForceUp;
                rigidbody.AddForce(force);
                break;
            case State.WalkingAway: {
                    GameObject jumpedOverObject = GameObject.FindWithTag(jumpedOverObjectTag);
                    rotationVector.Set(jumpedOverObject.transform.position.x, transform.position.y, jumpedOverObject.transform.position.z);
                    transform.LookAt(rotationVector);
                    transform.Rotate(transform.up, 180);

                    rigidbody.AddForce(-force);
                    force = transform.forward * walkForce;
                    rigidbody.AddForce(force);
                }
                break;
        }
    }
}
