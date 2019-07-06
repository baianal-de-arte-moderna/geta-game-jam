using UnityEngine;

public class BedBehaviourScript : MonoBehaviour
{
    public string sceneName;
    public Animator thoughts;
    public SceneTransitionAnimation sceneTransition;

    public void Select()
    {
        thoughts.gameObject.SetActive(true);
        thoughts.SetTrigger("FadeIn");
    }

    public void Unselect()
    {
        thoughts.SetTrigger("FadeOut");
    }

    public void Interact()
    {
        sceneTransition.ChangeScene(sceneName);
    }
}
