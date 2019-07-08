/* vim: set ts=4 sts=4 sw=4 expandtab: */
using UnityEngine;

public class DreamSceneScenarioItem : InteractableObject {
    public override void InteractAt(Vector3 position) {
        if (PlayerInventory.hasObject) {
            PlayerInventory.DropObjectAt(position);
        }
    }
}
