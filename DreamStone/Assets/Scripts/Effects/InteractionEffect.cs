using UnityEngine;

public abstract class InteractionEffect : MonoBehaviour {
    public abstract void Start();
    public abstract void Apply();
    public abstract void Clear();
}
