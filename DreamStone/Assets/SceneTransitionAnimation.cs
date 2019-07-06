using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionAnimation : MonoBehaviour
{
    Color targetColor;
    public Image panel;
    public float transitionSpeed;
    // Start is called before the first frame update
    void Start()
    {
        targetColor = Color.clear;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        panel.color = Color.Lerp(
            panel.color,
            targetColor,
            transitionSpeed
        );
    }

    public void ChangeScene(string sceneName)
    {
        targetColor = Color.white;
        StartCoroutine(LoadScene(sceneName));
    }

    IEnumerator LoadScene(string name)
    {
        yield return new WaitForSeconds(0.1f / transitionSpeed);
        SceneManager.LoadScene(name);
    }
}
