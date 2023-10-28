using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HandBossController : MonoBehaviour
{
    public enum COMBAT_STATE
    {
        SEEKING = 0,
        ATTACKING = 1,
        DESCENDING = 2,
        STUN = 3,
        INTRO = 4
    }

    [SerializeField] private Transform player;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private LayerMask spikeLayer;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask hitLayer;
    [SerializeField] private float yLevel;
    [SerializeField] private float verticalSpeed;
    private Rigidbody2D rb;
    private Animator animator;

    private float time;
    public COMBAT_STATE combat_state;
    public float hitThreshold = 0.1f;
    public float attackSpeed = 10f;
    public int stunTime = 3;
    public float attackDelay = 1f;

    public float attackDelayTimer;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        combat_state = COMBAT_STATE.INTRO;
        attackDelayTimer = attackDelay;
    }
    private void FixedUpdate()
    {
        switch (combat_state)
        {
            case COMBAT_STATE.INTRO:
                // INTRO
                rb.MovePosition(transform.position + Vector3.down * Time.fixedDeltaTime * 0.2f); break;
            case COMBAT_STATE.SEEKING:
                if (transform.position.y < yLevel)
                    //RETURN TO TOP OF SCREEN
                    rb.MovePosition(transform.position + (Vector3.up * verticalSpeed) * Time.fixedDeltaTime);

                else if ((Mathf.Abs(transform.position.x - player.position.x) <= hitThreshold) )// found player -> Strike!
                {
                    if (attackDelayTimer > 0)
                    {
                        attackDelayTimer -= Time.fixedDeltaTime;
                    }
                    else {
                        Attack();  //Attack!
                 

                        Debug.Log("Attacking");
                        attackDelayTimer = attackDelay;
                    }

                  
                }
                else  // FOLLOW PLAYER X
                {

                    Vector3 playerDir = player.position - transform.position;

                    playerDir.y = 0;
                    playerDir.z = 0;

                    rb.MovePosition(transform.position + playerDir.normalized * verticalSpeed * Time.fixedDeltaTime);

                }
                break;
            case COMBAT_STATE.DESCENDING:
                // GO FARTHER !!!
                rb.MovePosition(transform.position + (Vector3.down * verticalSpeed) * Time.fixedDeltaTime);

                break;
            case COMBAT_STATE.STUN:


                rb.velocity = Vector3.zero;
                break;
            case COMBAT_STATE.ATTACKING:
                rb.MovePosition(transform.position + Vector3.down * attackSpeed * Time.fixedDeltaTime);
                break;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((playerLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            //Hand Hits palyer: Kill player!!

            Debug.Log("Hand Hit player: he dead :p");
        }
        else if ((spikeLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            //Hand Hits spike

            Debug.Log("Hand hits spike: STUN");
            Stun();

            //Screen Shake
        }
        else if ((groundLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            //Hand Hits Ground

            Debug.Log("Hand hits Ground: Seek");
            Seek();

            //Shake the screen here
        }
        else if ((hitLayer.value & (1 << collision.gameObject.layer)) < 0)
        {
            //Player hits hand ?????????

            Debug.Log("HITTING");
            Hit();

            //Shake the Screen 
        }
    }

    public void Hit()
    {
        
        animator.SetInteger("Health", animator.GetInteger("Health") - 1);
        animator.SetTrigger("Hit");
    }    

    public void Descend()
    {
        combat_state = COMBAT_STATE.DESCENDING;
    }

    public void Seek()
    {
        combat_state = COMBAT_STATE.SEEKING;
    }

    public void Stun()
    {
        animator.SetTrigger("Stun");
        combat_state = COMBAT_STATE.STUN;
        StartCoroutine("Stun_CountDown");
    }

    // Called when seek timer runs out
    public void Attack()
    {
        combat_state = COMBAT_STATE.ATTACKING;
    }





     IEnumerator Stun_CountDown()
    {
        int counter = stunTime;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }

        // move to seek
        Seek();
    }

    IEnumerator Seek_CountDown()
    {
        float counter = attackDelay;
        while (counter > 0)
        {
            yield return new WaitForSeconds(.05f);
            counter-=0.51f;
        }

        // Attack
        Attack();
    }



}
