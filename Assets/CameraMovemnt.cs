using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float zoomSpeed = 1f;
    [SerializeField] private float zoomMin = 20f;
    [SerializeField] private float zoomMax = 60f;
    [SerializeField] private float verticalMin = -10f;
    [SerializeField] private float verticalMax = 10f;

    private Transform tr;
    private Camera cam;

    private void Start()
    {
        tr = GetComponent<Transform>();
        cam = Camera.main;
    }

    private void Update()
    {
        HandleMovement();
        HandleZoom();
    }

    private void HandleMovement()
    {
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float newZ = Mathf.Clamp(tr.position.z + move, verticalMin, verticalMax);
        tr.position = new Vector3(tr.position.x, tr.position.y, newZ);
    }

    private void HandleZoom()
    {
        float scroll = Input.mouseScrollDelta.y * zoomSpeed;
        float newFov = Mathf.Clamp(cam.fieldOfView - scroll, zoomMin, zoomMax);
        cam.fieldOfView = newFov;
    }
}