using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCamera : MonoBehaviour
{
    Camera mainCamera;

    [SerializeField]
    float zoomModifier = 0.1f;

    public bool Bounds;

    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    public float dragSpeed = 0.5f;
    private Vector3 dragOrigin;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        minCameraPos.z = -100f;
        maxCameraPos.z = -100f;
    }

    // Update is called once per frame
    void Update()
    {
        minCameraPos.x = -10f - 2 * (5 - mainCamera.orthographicSize);
        maxCameraPos.x = 10f + 2 * (5 - mainCamera.orthographicSize);
        minCameraPos.y = -5f - (5 - mainCamera.orthographicSize);
        maxCameraPos.y = 5f + (5 - mainCamera.orthographicSize);
        

        if (Bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));
        }
        if (Input.GetKeyDown(KeyCode.Equals))
        {
            mainCamera.orthographicSize += zoomModifier;
        }
        if (Input.GetKeyDown(KeyCode.Minus))
        {
            mainCamera.orthographicSize -= zoomModifier;
        }

        mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize, 2f, 5f);

        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        Vector3 pos = mainCamera.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
        Vector3 move = new Vector3(-pos.x * dragSpeed, -pos.y * dragSpeed, 0);

        transform.Translate(move, Space.World);
    }
}
