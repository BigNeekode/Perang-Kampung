using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovemnt : MonoBehaviour
{
    Transform tr;
    public float speed = 10f;
    public float zoomMin = 10f;
    public float zoomMax = 45f;
    public float VerticalMax = 25f;
    public float VerticalMin = -25f;

    private void Start()
    {
        tr = GetComponent<Transform>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D)&& tr.position.z <= VerticalMax)
        {
            tr.position += new Vector3(0,0,1) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) && tr.position.z >= VerticalMin)
        {
            tr.position -= new Vector3(0,0,1) * speed * Time.deltaTime;
        }

        // scroll mouse wheel to zoom in/out editing the camera fov
        if (Input.mouseScrollDelta.y > 0 && Camera.main.fieldOfView > zoomMin)
        {
            Camera.main.fieldOfView -= 1;
        }
        if (Input.mouseScrollDelta.y < 0 && Camera.main.fieldOfView < zoomMax)
        {
            Camera.main.fieldOfView += 1;
        }



    }
}
