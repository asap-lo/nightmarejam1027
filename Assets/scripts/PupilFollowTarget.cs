using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;
public class PupilFollowTarget : MonoBehaviour
{
    public Transform eye;
    public Transform target;
    public float lookSpeed = 10;

    // Update is called once per frame
    // When this gameobject becomes active, this will follow the target.



    private void Start()
    {
        if (target == null)
        {
            target = FindObjectOfType<PlayerController>().transform;
        }
        if (eye == null)
        {
            eye = this.transform.GetChild(0);
        }
    }


    void LateUpdate()
    {
        Vector3 to = target.position - eye.position;

        eye.right = Vector3.RotateTowards(eye.right, to, lookSpeed * Time.deltaTime, 0) ;

       

    }
}
