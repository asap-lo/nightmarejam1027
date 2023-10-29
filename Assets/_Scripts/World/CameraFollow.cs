using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float positionSmoothSpeed = .125f;
    public float zoomSmoothSpeed = .125f;
    public Vector3 offset;

    [Range(1, 179)]
    public float zoom;

    Camera cam;

    private void Awake()
    {
        cam = GetComponentInChildren<Camera>();
    }
    private void FixedUpdate()
    {
        //smooth position change
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, positionSmoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;


        //smooth Zoom change
        float desiredZoom = zoom;
        float smoothedZoom = Mathf.Lerp(cam.fieldOfView, desiredZoom, zoomSmoothSpeed * Time.deltaTime);
        cam.fieldOfView = smoothedZoom;

    }

}
