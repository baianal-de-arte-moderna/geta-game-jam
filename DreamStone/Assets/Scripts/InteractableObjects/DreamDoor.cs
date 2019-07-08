/* vim: set ts=4 sts=4 sw=4 expandtab: */
using UnityEngine;
using UnityEngine.SceneManagement;

public class DreamDoor : InteractableObject {
    [SerializeField] private string transitionToSceneName;

    public override void InteractAt(Vector3 position) {
        SceneManager.LoadScene(transitionToSceneName);
    }
}
