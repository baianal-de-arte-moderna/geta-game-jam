using UnityEngine;

public class WalkForwardBehaviour : BaseBehaviour {

    [SerializeField]
    private float walkForce;

    private enum State {
        Idle,
        Walking,
        Dead
    }

    private new Rigidbody rigidbody;
    private Vector3 startPosition;
    private State state;
    private Vector3 force;
    private float accumulatedTime;

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
        if (state == State.Dead) {
            accumulatedTime += Time.deltaTime;
            if (accumulatedTime > 5f) {
                SetState(State.Idle);
            }
        }
    }

    private void SetState(State newState) {
        Debug.Log($"Change state from {state} to {newState}");

        state = newState;
        switch (state) {
            case State.Idle:
                transform.position = startPosition;
                break;
            case State.Walking:
                rigidbody.AddForce(-force);
                force = transform.forward * walkForce;
                rigidbody.AddForce(force);
                break;
            case State.Dead:
                rigidbody.AddForce(-force);
                force = Vector3.zero;
                accumulatedTime = 0f;
                break;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Cliff") && state == State.Idle) {
            SetState(State.Walking);
        } else if (collision.collider.CompareTag("Floor") && state == State.Walking) {
            SetState(State.Dead);
        }
    }
}
