using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDScript : MonoBehaviour {

    [SerializeField]
    private Image backgroundImage;

    [SerializeField]
    private Image sheepImage;

    [SerializeField]
    private Image fenceImage;

    [SerializeField]
    private Image haystackImage;

    private void Update() {
        string pickedObjectType = DreamManager.GetPickedObjectType();
        backgroundImage.enabled = pickedObjectType != null;
        sheepImage.enabled = pickedObjectType == "sheep";
        fenceImage.enabled = pickedObjectType == "fence";
        haystackImage.enabled = pickedObjectType == "haystack";
    }
}
