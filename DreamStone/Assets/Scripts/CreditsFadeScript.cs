using UnityEngine;
using TMPro;

public class CreditsFadeScript : MonoBehaviour
{
    public float fadeInTime;
    public float fadeOutTime;
    float timer;

    public MeshRenderer render;
    public TMP_Text text;

    Color targetColor;
    Color color
    {
        get
        {
            if (render != null)
            {
                return render.material.GetColor("_BaseColor");
            }
            return text.color;
        }
        set
        {
            if (render != null)
            {
                render.material.SetColor("_BaseColor", value);
            }
            if (text != null)
            {
                text.color = value;
            }
        }
    }

    void Start()
    {
        color = Color.clear;
        timer = 0f;
    }

    
    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;

        if (timer > fadeInTime && timer < fadeOutTime)
        {
            targetColor = Color.white;
        }
        else if (timer > fadeOutTime || timer < fadeInTime)
        {
            targetColor = Color.clear;
        }

        color = Color.Lerp(color, targetColor, 0.02f);
    }
}
