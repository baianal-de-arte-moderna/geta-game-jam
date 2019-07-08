using UnityEngine;

public class EnlargeEffect : InteractionEffect {
    [SerializeField] private float enlargeRatio;

    private Vector3 originalScale;

    public override void Apply() {
        transform.localScale *= (1f + enlargeRatio / 100f);
    }

    public override void Clear() {
        transform.localScale = originalScale;
    }

    public override void Start() {
        originalScale = transform.localScale;
    }
}

