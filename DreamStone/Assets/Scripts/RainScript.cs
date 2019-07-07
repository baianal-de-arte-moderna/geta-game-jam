using UnityEngine;

public class RainScript : MonoBehaviour {
    public float thunderIntensity;
    public ThunderScript[] thunders;
    public Material material;

    private void Start() {
        Invoke("Thunder", 0f);
    }

    private void Thunder() {
        float baseRandom = Random.Range(10f / thunderIntensity, 10f);
        foreach (ThunderScript thunder in thunders) {
            float diff = Random.Range(-0.5f, 0.5f);
            thunder.Flash(baseRandom + diff);
            Invoke("RainEmissionOn", diff);
        }
        Invoke("Thunder", baseRandom);
    }

    private void RainEmissionOn() {
        material.EnableKeyword("_EMISSION");
        Invoke("RainEmissionOff", 0.1f);
    }

    private void RainEmissionOff() {
        material.DisableKeyword("_EMISSION");
    }
}
