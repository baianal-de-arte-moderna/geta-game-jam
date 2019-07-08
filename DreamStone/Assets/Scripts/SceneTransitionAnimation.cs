using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionAnimation : MonoBehaviour {
    private Color targetColor;
    public Image panel;
    public float transitionSpeed;
    public bool startFade;

    // Start is called before the first frame update
    private void Start() {
        gameObject.SetActive(true);
        if (startFade) {
            targetColor = Color.clear;
        } else {
            targetColor = panel.color;
        }
    }

    // Update is called once per frame
    private void FixedUpdate() {
        panel.color = Color.Lerp(
            panel.color,
            targetColor,
            transitionSpeed
        );
    }

    public void ChangeScene(string sceneName) {
        targetColor = Color.black;
        StartCoroutine(LoadScene(sceneName));
    }

    private IEnumerator LoadScene(string name) {
        yield return new WaitForSeconds(0.2f / transitionSpeed);
        SceneManager.LoadScene(name);
    }
}
