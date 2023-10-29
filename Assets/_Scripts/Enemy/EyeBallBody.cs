using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EyeBallBody : MonoBehaviour
{
    public LineRenderer lineRend;
    public int length;
    public Vector3[] segmentPoses;
    public Vector3[] segmentV;

    public Transform targetDir;
    public float targetDist;
    public float smoothSpeed;
    public float trailSpeed;

    public float wiggleSpeed;
    public float wiggleMagnitude;

    public Transform wiggleDirection;

    // Start is called before the first frame update
    void Start()
    {
       

        for (int i = 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.zero;
        }

        //lineRend.useWorldSpace = true;

        lineRend.SetPositions(segmentPoses);

        lineRend.positionCount = length;
        segmentPoses = new Vector3[length];
        segmentV = new Vector3[length];
        StartCoroutine("ActivateLine");

    }

    // Update is called once per frame
    void Update()
    {
        wiggleDirection.localRotation = Quaternion.Euler(0,0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);

        segmentPoses[0] = targetDir.position;

        for (int i= 1; i < segmentPoses.Length; i++)
        {
            segmentPoses[i] = Vector3.SmoothDamp(segmentPoses[i],segmentPoses[i-1] + targetDir.right * targetDist,ref segmentV[i],smoothSpeed + i /trailSpeed);
        }

        lineRend.SetPositions(segmentPoses);
    }


    IEnumerator ActivateLine()
    {
        int counter = 3;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        lineRend.useWorldSpace = true;
    }

}
