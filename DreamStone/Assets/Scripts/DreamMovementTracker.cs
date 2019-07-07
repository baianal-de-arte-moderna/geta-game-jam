using UnityEngine;

public class DreamMovementTracker : MonoBehaviour {

    public InteractableObject currentlyFocusedItem { get; private set; }

    private void Update() {
        Ray currentMouseRaycast = Camera.main.ScreenPointToRay(
            Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);

        if (Physics.Raycast(currentMouseRaycast, out RaycastHit hoverObject, 1000f, LayerMask.GetMask("Interactable"))) {
            InteractableObject sceneItem = hoverObject.transform.
                GetComponent<InteractableObject>();

            if (sceneItem == null) {
                Debug.Log("ALL OBJECTS IN THE INTERACTABLE LAYER SHOULD BE INTERACTABLEOBJECTS YOU MORON!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }

            if (currentlyFocusedItem != sceneItem) {
                currentlyFocusedItem?.ClearFocus();
                currentlyFocusedItem = sceneItem;
                sceneItem.SetFocus();
            }
        } else {
            currentlyFocusedItem?.ClearFocus();
            currentlyFocusedItem = null;
        }
    }

}
