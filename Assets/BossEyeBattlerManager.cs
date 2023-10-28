using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEyeBattlerManager : MonoBehaviour
{
    public List<BossEye> eyes = new List<BossEye>();


    public int numberOfRounds = 3;



    public int currentRound = 0;

    public bool nextRound = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        for (int i= 0; i <= numberOfRounds; i++ )
        {

            if (currentRound == i)
            {
                if (nextRound)
                {
                    currentRound++;
                    FiringOrder();
                }
                
            }


        }



    }




    public void FiringOrder()
    {
        reshuffle();

        for (int i = 0; i < eyes.Count;i++)
        {
            eyes[i].idleTime = i * 2;
        }
    }


    void reshuffle()
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < eyes.Count; t++)
        {
            BossEye tmp = eyes[t];
            int r = Random.Range(t, eyes.Count);
            eyes[t] = eyes[r];
            eyes[r] = tmp;
        }
    }

}
