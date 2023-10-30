using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{

    public  int currentCheckpoint = 0;

    public List<Transform> checkpoints;
    public GameObject player;

    public int respawnTime = 3;

    private bool playerDead = false;
    // Start is called before the first frame update
    void Start()
    {
        GameEventSystem.PlayerDeath += respawnPlayer;

        GameEventSystem.IncreaseCheckpoint += IncreaseCheckPoint;
    }


    public void respawnPlayer()
    {
        if (playerDead == false)
        {
            StartCoroutine("spawnPlayer");
            playerDead = true;
            
        }
       

       
    }


    void IncreaseCheckPoint()
    {


        currentCheckpoint++;
        Debug.Log("Checkpoint reached! " + currentCheckpoint);
    }




    IEnumerator spawnPlayer()
    {
        int counter = respawnTime;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }

        player.transform.position = checkpoints[currentCheckpoint].position;
        GameEventSystem.OnRespawnPlayer();
        playerDead = false;
    }
}
