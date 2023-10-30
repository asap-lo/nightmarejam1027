using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
public class BossEyeBattlerManager : MonoBehaviour
{


    public List<stage>  stages = new List<stage>();
    public BossEye bossEyePrefab;
    public int startDelay = 5;
    public int numberOfRounds = 3;

    public int currentRound = 0;

    public bool nextRound = false;

    public Transform pupilFollow;

    public static BossEyeBattlerManager current;


    public int startBossDelay = 3;

    private void Awake()
    {
        current = this;
    }




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
                    nextRound = false;
                }
              
            }
        }

    }




    public void SpawnEyes()
    {
        //  reshuffle();

        //get number of spawn postiison

        Debug.Log("currentorund: " + currentRound);

        List<Transform> spawnPos = stages[currentRound].spawnPosiStions;
        Debug.Log("stage: " + spawnPos.Count);

        for (int i = 0; i < spawnPos.Count; i++)
        {
            Debug.Log("i : " + i);
            BossEye g = Instantiate(bossEyePrefab, spawnPos[i].position , Quaternion.identity, this.transform);
            g.GetComponent<PupilFollowTarget>().target = pupilFollow;
            g.idleTime = startDelay;
            startDelay += 1;
            g.StartBoss();
           
        }

        currentRound++;
    }





    public static event UnityAction StartBoss;
   
    public static void OnStartBoss () => StartBoss?.Invoke();


    public static event UnityAction KillLazer;

    public static void OnKillLazer() => KillLazer?.Invoke();

    public static event UnityAction NextRound;

    public static void OnNextRound() => NextRound?.Invoke();



    public static event UnityAction FinishBoss;

    public static void OnFinish() => FinishBoss?.Invoke();





    IEnumerator StartBossDelay()
    {
        int counter = startBossDelay;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }

        OnStartBoss();
    }



}


[System.Serializable]
public class stage
{
    public List<Transform> spawnPosiStions;


}


