/* vim: set ts=4 sts=4 sw=4 expandtab: */
using UnityEngine;

public class DreamPlayerInputController : MonoBehaviour {
    [Tooltip("The movement tracker instance for the current scene")]
    public DreamMovementTracker movementTracker;

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (movementTracker.currentlyFocusedItem != null) {
                movementTracker.currentlyFocusedItem.focusedGameObject.InteractAt(
                    movementTracker.currentlyFocusedItem.focusedWorldPoint);
            }

            //if (movementTracker?.currentlyFocusedItem != null) {
            //    PlayerInventory.PickObject(movementTracker.currentlyFocusedItem.gameObject);
            //} else {
            //    Ray placementRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            //    if (Physics.Raycast(placementRay, out RaycastHit placement, 1000f,
            //        LayerMask.GetMask("Scenario"))) {
            //        PlayerInventory.DropObjectAt(placement.point);
            //    }
            //}
        }
    }
}
