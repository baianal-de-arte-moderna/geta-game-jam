using UnityEngine;

public class DreamMovementTracker : MonoBehaviour {

    public class FocusedObject {
        public InteractableObject focusedGameObject;
        public Vector3 focusedWorldPoint;
    }
    public FocusedObject currentlyFocusedItem { get; private set; }

    private void Start() {
        currentlyFocusedItem = null;
    }

    private void Update() {
        Ray currentMouseRaycast = Camera.main.ScreenPointToRay(
            Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);

        if (Physics.Raycast(currentMouseRaycast, out RaycastHit hoverObject, 1000f, LayerMask.GetMask("Interactable"))) {
            InteractableObject sceneItem = hoverObject.transform.
                GetComponent<InteractableObject>();

            if (sceneItem == null) {
                Debug.Log("ALL OBJECTS IN THE INTERACTABLE LAYER SHOULD BE INTERACTABLEOBJECTS YOU MORON!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                return;
            }

            if (currentlyFocusedItem == null) {
                currentlyFocusedItem = new FocusedObject();
            } else {
                currentlyFocusedItem.focusedGameObject.ClearFocus();
            }

            currentlyFocusedItem.focusedGameObject = sceneItem;
            currentlyFocusedItem.focusedWorldPoint = hoverObject.point;
            sceneItem.SetFocus();
        } else {
            currentlyFocusedItem?.focusedGameObject.ClearFocus();
            currentlyFocusedItem = null;
        }
    }

}
