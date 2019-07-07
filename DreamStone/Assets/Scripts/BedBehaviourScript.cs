using UnityEngine;

public class BedBehaviourScript : MonoBehaviour
{
    public string sceneName;
    public Animator thoughts;
    public SceneTransitionAnimation sceneTransition;

    public void Select()
    {
        thoughts.gameObject.SetActive(true);
        thoughts.SetBool("Fade", true);
    }

    public void Unselect()
    {
        thoughts.SetBool("Fade", false);
    }

    public void Interact()
    {
        sceneTransition.ChangeScene(sceneName);
    }
}
