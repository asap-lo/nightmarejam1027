using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
public class BossEyeBattlerManager : MonoBehaviour
{


    public List<stage>  stages = new List<stage>();
    public BossEye bossEyePrefab;
    
    public int numberOfRounds = 3;

    public int currentRound = 0;

    public Transform pupilFollow;


    public int startBossDelay = 3;


    public bool StopFight = true;

    public int numEyesInRound;
    public int numEyesLeft;

    private void Start()
    {


        StartBoss += StartRound;
        KillLazer += onLazerKilled;


        FinishBoss += FinishBossMethod;

        NextRound += NextRoundMethod;


        StartCoroutine("StartBossDelay");
    }


    void StartRound()
    {
        Debug.Log("BOSS: Start");

        SpawnEyes();
    }


    void FinishBossMethod()
    {
        Debug.Log("BOSS: Boss Over!");
    }
    void NextRoundMethod()
    {
        currentRound++;
        Debug.Log("BOSS: Next Round");
        if (currentRound >= numberOfRounds)
        {


            OnFinish();
        }
        else {
            SpawnEyes();
        }



    }

    void onLazerKilled()
    {
        numEyesLeft--;
        Debug.Log("BOSS: Lazor Killed");
        //End of Round!
        if (numEyesLeft == 0)
        {
            OnNextRound();

        }
    }





    public void SpawnEyes()
    {
        //  reshuffle();

        //get number of spawn postiison

        Debug.Log("currentorund: " + currentRound);

        List<Transform> spawnPos = stages[currentRound].spawnPosiStions;
        Debug.Log("stage: " + spawnPos.Count);

        numEyesInRound = spawnPos.Count;


        for (int i = 0; i < spawnPos.Count; i++)
        {
            Debug.Log("i : " + i);
            BossEye g = Instantiate(bossEyePrefab, spawnPos[i].position , Quaternion.identity, this.transform);
            g.GetComponent<PupilFollowTarget>().target = pupilFollow;
            g.idleTime = i;
                    g.StartBoss();
            numEyesLeft++;
           
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
        StopFight = false;
    }



}


[System.Serializable]
public class stage
{
    public List<Transform> spawnPosiStions;


}


