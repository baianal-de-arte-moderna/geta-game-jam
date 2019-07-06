/* vim: set ts=4 sts=4 sw=4 expandtab: */
using UnityEngine;

public abstract class BaseBehaviour : MonoBehaviour {
    public BehaviourManager behaviourManager;

    public int priority;

    public abstract bool IsActive();

    public abstract bool InterruptChain();

    public abstract void Iterate();

    void Start() {
        behaviourManager?.RegisterBehaviour(this);
    }
}
