using UnityEngine;

public class BallControlScript : MonoBehaviour {
    public string navigationPlaneLayer;
    public GameObject player;
    private Transform playerInstance;
    private int layerMask;

    // Start is called before the first frame update
    private void Start() {
        playerInstance = Instantiate(player).transform;
        playerInstance.SetParent(transform);
        layerMask = LayerMask.GetMask(navigationPlaneLayer);
    }

    // Update is called once per frame
    private void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 500.0f, layerMask)) {
            transform.position = Vector3.Lerp(
                transform.position,
                hit.point,
                0.2f
            );
        }
    }
}
