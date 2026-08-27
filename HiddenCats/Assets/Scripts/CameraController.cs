using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera playerCam;
    private float zoomSensitivity = 1f;
    private float zoomSpeed = 10f;
    private float minZoom = 5f;
    private float maxZoom = 20f;
    private float targetZoom;

    void Awake()
    {
        playerCam = GetComponent<Camera>();
    }

    void Start()
    {
        targetZoom = playerCam.orthographicSize;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Click and drag to move the camera around the scene.
            float h = Input.GetAxis("Mouse X"); // Horizontal mouse movement.
            float v = Input.GetAxis("Mouse Y"); // Vertical mouse movement.
            transform.Translate(-h, -v, 0);
        }
        targetZoom -= Input.mouseScrollDelta.y * zoomSensitivity;
        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
        float newZoom = Mathf.Lerp(playerCam.orthographicSize, targetZoom, Time.deltaTime * zoomSpeed);
        playerCam.orthographicSize = newZoom;
    }
}
//@Felidae_studios