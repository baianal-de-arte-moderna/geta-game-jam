using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections;

[Serializable]
public class ObjectReachedEvent : UnityEvent<bool> {}

public class WalkTowardsObjectBehaviour : BaseBehaviour {

    [SerializeField]
    private string walkedTowardsObjectTag;

    [SerializeField]
    private float walkForce;

    [SerializeField]
    private ObjectReachedEvent objectReached;

    private enum State {
        Idle,
        WalkingTowards,
        ObjectReached,
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
        bool isActive = GameObject.FindWithTag(walkedTowardsObjectTag) != null;
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

    private void OnCollisionStay(Collision collision) {
        if (state == State.WalkingTowards && collision.collider.CompareTag(walkedTowardsObjectTag)) {
            SetState(State.ObjectReached);
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

        state = newState;
        switch (state) {
            case State.Idle:
                rigidbody.AddForce(-force);
                force = Vector3.zero;
                break;
            case State.WalkingTowards: {
                    GameObject jumpedOverObject = GameObject.FindWithTag(walkedTowardsObjectTag);
                    rotationVector.Set(jumpedOverObject.transform.position.x, transform.position.y, jumpedOverObject.transform.position.z);
                    transform.LookAt(rotationVector);

                    rigidbody.AddForce(-force);
                    force = transform.forward * walkForce;
                    rigidbody.AddForce(force);
                    break;
                }
            case State.ObjectReached:
                force = Vector3.zero;
                break;
        }

        objectReached?.Invoke(state == State.ObjectReached);
    }
}
