using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControlScript : MonoBehaviour
{
    public string navigationPlaneLayer;
    public GameObject player;

    Transform playerInstance;
    int layerMask;
    // Start is called before the first frame update
    void Start()
    {
        playerInstance = Instantiate(player).transform;
        playerInstance.SetParent(transform);
        layerMask = LayerMask.GetMask(navigationPlaneLayer);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f, layerMask))
        {
            transform.position = Vector3.Lerp(
                transform.position,
                hit.point,
                0.2f
            );
        }
    }
}
