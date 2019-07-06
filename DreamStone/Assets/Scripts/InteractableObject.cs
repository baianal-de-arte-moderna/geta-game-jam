using UnityEngine;

public class InteractableObject : MonoBehaviour {
    private bool focused;
    private Vector3 originalScale;

    void Start() {
        focused = false;
        originalScale = this.transform.localScale;
    }

    public void SetFocus() {
        focused = true;
        this.transform.localScale *= 1.1f;
    }

    public void ClearFocus() {
        focused = false;
        this.transform.localScale = originalScale;
    }

}
