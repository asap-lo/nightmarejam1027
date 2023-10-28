using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossEyeBattlerManager : MonoBehaviour
{


    public List<stage>  stages = new List<stage>();
    public BossEye bossEyePrefab;
    public int startDelay = 5;
    public int numberOfRounds = 3;

    public int currentRound = 0;

    public bool nextRound = false;

    public Transform pupilFollow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        for (int i= 0; i < stages.Count; i++ )
        {

            if (currentRound == i)
            {
                if (nextRound)
                { 
                    SpawnEyes();
                }
              
            }
        }

    }




    public void SpawnEyes()
    {
        //  reshuffle();

        //get number of spawn postiison

        Debug.Log("currentorund: " + currentRound);

        List<Vector3> spawnPos = stages[currentRound].spawnPosiStions;
        Debug.Log("stage: " + spawnPos.Count);

        for (int i = 0; i < spawnPos.Count; i++)
        {
            Debug.Log("i : " + i);
            BossEye g = Instantiate(bossEyePrefab, spawnPos[i] , Quaternion.identity, this.transform);
            g.GetComponent<PupilFollowTarget>().target = pupilFollow;
            g.idleTime = startDelay + i;
            g.StartBoss();
           
        }

        currentRound++;
    }


}


[System.Serializable]
public class stage
{
    public List<Vector3> spawnPosiStions;


}


