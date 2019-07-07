using UnityEngine;

public class BallWobbleScript : MonoBehaviour {
    public float wobbleIntensity;

    private void Update() {
        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            Random.insideUnitSphere,
            wobbleIntensity / 10f
            );
    }
}
