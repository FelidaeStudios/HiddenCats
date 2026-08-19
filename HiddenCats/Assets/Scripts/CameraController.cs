using UnityEngine;

public class CameraController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // click and drag to move the camera around the scene.
            float h = Input.GetAxis("Mouse X"); // Horizontal mouse movement.
            float v = Input.GetAxis("Mouse Y"); // Vertical mouse movement.
            transform.Translate(-h, -v, 0);
        }
    }
}
