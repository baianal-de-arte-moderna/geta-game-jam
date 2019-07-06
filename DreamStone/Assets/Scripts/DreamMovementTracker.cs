using UnityEngine;

public class DreamMovementTracker : MonoBehaviour {

    public InteractableObject currentlyFocusedItem { get; private set; }

    void Update() {
        Ray currentMouseRaycast = Camera.main.ScreenPointToRay(
            Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);

        RaycastHit hoverObject;
        if (Physics.Raycast(currentMouseRaycast, out hoverObject) ) {
            InteractableObject sceneItem = hoverObject.transform.
                GetComponent<InteractableObject>();

            if (sceneItem != null) {
                if (currentlyFocusedItem != sceneItem) {
                    currentlyFocusedItem?.ClearFocus();
                    currentlyFocusedItem = sceneItem;
                    sceneItem.SetFocus();
                }
            } else {
                currentlyFocusedItem?.ClearFocus();
                currentlyFocusedItem = null;
            }
        } else {
            currentlyFocusedItem?.ClearFocus();
            currentlyFocusedItem = null;
        }
    }

}
