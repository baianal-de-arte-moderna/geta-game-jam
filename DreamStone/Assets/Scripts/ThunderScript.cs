using UnityEngine;

public class ThunderScript : MonoBehaviour {
    private new Light light;

    // Start is called before the first frame update
    private void Start() {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    private void Update() {
        light.color = Color.Lerp(
            light.color,
            Color.clear,
            0.1f
        );
    }

    public void Flash(float delay) {
        Invoke("Flash", delay);
    }

    public void Flash() {
        light.color = Color.white;
    }
}
