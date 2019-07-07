using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class InteractableObject : MonoBehaviour {
    [SerializeField] private InteractionEffect effect;

    public bool IsFocused { get; private set; }

    public abstract void InteractAt(Vector3 position);

    public virtual void SetFocus() {
        IsFocused = true;
        effect?.Apply();
    }

    public virtual void ClearFocus() {
        effect?.Clear();
        IsFocused = false;
    }
}
