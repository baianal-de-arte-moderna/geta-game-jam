using UnityEngine;

public class InteractableObject : MonoBehaviour {
    private bool focused;
    private Vector3 originalScale;

    private void Start() {
        focused = false;
        originalScale = transform.localScale;
    }

    public void SetFocus() {
        focused = true;
        transform.localScale *= 1.1f;
    }

    public void ClearFocus() {
        focused = false;
        transform.localScale = originalScale;
    }

}
