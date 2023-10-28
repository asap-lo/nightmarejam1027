using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PupilFollowTarget : MonoBehaviour
{
    public Transform eye;
    public Transform target;

    // Update is called once per frame
    // When this gameobject becomes active, this will follow the target.
    void LateUpdate()
    {
        eye.LookAt(Vector3.forward, Vector3.Cross(Vector3.forward, target.position));
        
    }
}
