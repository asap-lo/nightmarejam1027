using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerCheckpoint : MonoBehaviour
{

    public bool alreadyReached = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            //hit spike: die
            if (alreadyReached == false)
            {
                alreadyReached = true;
                GameEventSystem.OnIncreaseCheckpoint();
            }
           


        }
    }
}
