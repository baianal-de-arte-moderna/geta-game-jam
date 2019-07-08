/* vim: set ts=4 sts=4 sw=4 expandtab: */
using UnityEngine;
using UnityEngine.SceneManagement;

public static class PlayerInventory {

    private static GameObject selectedObject { get; set; }

    public static bool hasObject => selectedObject != null;

    public static void PickObject(GameObject obj) {
        if (selectedObject == null) {
            selectedObject = obj;
            selectedObject.SetActive(false);

            DreamManager.PickObject(selectedObject);
        }
    }

    public static void DropObjectAt(Vector3 position) {
        if (selectedObject != null) {
            DreamManager.DropObject(selectedObject);

            selectedObject.transform.position = position;
            selectedObject.SetActive(true);
            selectedObject = null;
        }
    }
}
