/* vim: set ts=4 sts=4 sw=4 expandtab: */
using System.Collections.Generic;
using UnityEngine;

public class BehaviourManager : MonoBehaviour {

    private SortedDictionary<int, BaseBehaviour> m_behaviours = new SortedDictionary<int, BaseBehaviour>();

    private void FixedUpdate() {
        foreach (BaseBehaviour behaviour in m_behaviours.Values) {
            if (behaviour.IsActive()) {
                behaviour.Iterate();
                if (behaviour.InterruptChain()) {
                    break;
                }
            }
        }
    }

    public void RegisterBehaviour(BaseBehaviour behaviour) {
        if (m_behaviours.ContainsKey(behaviour.priority)) {
            Debug.Log("Priority conflict registering behaviour {0}", behaviour);
            throw new System.Exception(string.Format("Priority conflict registering behaviour {0}", behaviour));
        }

        m_behaviours[behaviour.priority] = behaviour;
    }
}
