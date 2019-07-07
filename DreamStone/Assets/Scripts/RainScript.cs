using UnityEngine;

public class RainScript : MonoBehaviour
{
    public float thunderIntensity;
    public ThunderScript[] thunders;
    public Material material;

    void Start()
    {
        Invoke("Thunder", 0f);
    }

    void Thunder()
    {
        var baseRandom = Random.Range(10f / thunderIntensity, 10f);
        foreach (var thunder in thunders)
        {
            var diff = Random.Range(-0.5f, 0.5f);
            thunder.Flash(baseRandom + diff);
            Invoke("RainEmissionOn", diff);
        }
        Invoke("Thunder", baseRandom);
    }

    void RainEmissionOn()
    {
        material.EnableKeyword("_EMISSION");
        Invoke("RainEmissionOff", 0.1f);
    }

    void RainEmissionOff()
    {
        material.DisableKeyword("_EMISSION");
    }
}
