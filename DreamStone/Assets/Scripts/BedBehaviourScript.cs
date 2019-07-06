using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedBehaviourScript : MonoBehaviour
{
    public string sceneName;

    public void Select()
    {
        transform.localScale *= 1.2f;
    }

    public void Unselect()
    {
        transform.localScale /= 1.2f;
    }

    public void Interact()
    {
        SceneManager.LoadScene(sceneName);
    }
}
