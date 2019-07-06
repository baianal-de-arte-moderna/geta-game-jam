using UnityEngine;
using UnityEngine.SceneManagement;

public class BedBehaviourScript : MonoBehaviour
{
    public string sceneName;
    public Animator thoughts;

    public void Select()
    {
        transform.localScale *= 1.2f;
        thoughts.gameObject.SetActive(true);
        thoughts.SetTrigger("FadeIn");
    }

    public void Unselect()
    {
        transform.localScale /= 1.2f;
        thoughts.SetTrigger("FadeOut");
    }

    public void Interact()
    {
        SceneManager.LoadScene(sceneName);
    }
}
