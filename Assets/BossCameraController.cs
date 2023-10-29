using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCameraController : MonoBehaviour
{
    private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private float zoomLowerBound = 10;
    [SerializeField] private float zoomUpperBound = 15;
    [SerializeField] private float deadzone = 1.1f;

    // Start is called before the first frame update
    void Start()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        // zoom out when camera is closer to x=0
        _virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(zoomUpperBound + deadzone, zoomLowerBound, Mathf.Abs(transform.position.x) / 24);
        if (zoomUpperBound < _virtualCamera.m_Lens.OrthographicSize)
            _virtualCamera.m_Lens.OrthographicSize = zoomUpperBound;
    }
}
