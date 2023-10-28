using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PupilFollowTarget : MonoBehaviour
{
    public Transform eye;
    public Transform target;
    public float lookSpeed;

    // Update is called once per frame
    // When this gameobject becomes active, this will follow the target.
    void LateUpdate()
    {
        Vector3 to = target.position - eye.position;

        eye.right = Vector3.RotateTowards(eye.right, to, lookSpeed * Time.deltaTime, 0) ;

       

    }
}
