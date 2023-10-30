using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEye : Enemy
{

    [Header("Boss Timing")]
    public float idleTime = 3f;
    public float lazorChargingTime = 3f;
    public float shootingTime = 3f;
    public float recoveryTime = 3f;



    [Header("Debug")]
    public float idle_Timer;
    public float lazorCharging_Timer;
    public float shooting_Timer;
    public float recovery_Timer;

    public states currentState = states.Idle;

    public bool startBoss = false;
    public enum states
    {
        Idle,
        Charging,
        Shooting,
        Recovering
    }
    
     private void Start()
    {
        anim = GetComponent<Animator>();


         //
         lazorCharging_Timer = lazorChargingTime;
         shooting_Timer = shootingTime;
         recovery_Timer = recoveryTime;

        currentState = states.Idle;
        currentHealth = maxHealth;
        camShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera_Shake>();

    }

    public override void TakeDamange(int amount, Transform damageSource, float knockback)
    {
        //Die is called from the an anim event
        anim.SetTrigger("Recover");
       

      
       
        //Knockback_FeedBack(damageSource, knockback);
        if (camShake != null)
        {
            StartCoroutine(camShake.Shake(shake_Duration, shake_Magnitude));
        }

    
}

    private void Update()
    {
        if (!startBoss)
        {
            return;
        }

        if (currentState == states.Idle)
        {
            // Play Idle Animation
            // count down from idleTime
            // Shoudl this be asigned by some manager to establish order?

            //transition to Charging


            if (idle_Timer > 0)
            {
                idle_Timer -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Charging");
                anim.SetTrigger("Charge");
                currentState = states.Charging;
            }
        }
        else if (currentState == states.Charging)
        {
            // Play Charging animation
            //count down from lazerChargeTime

            // Transition to shooting

            if (lazorChargingTime > 0)
            {
                lazorChargingTime -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Shooting");
                anim.SetTrigger("Shoot");
                currentState = states.Shooting;
            }

        }

        else if (currentState == states.Shooting)
        {

            //Play shooting animation
            //Deal damage to ship

            // player lose immediately?
           

            //Not sure if we need this but just in case
            if (shooting_Timer > 0)
            {
                shooting_Timer -= Time.deltaTime;
            }
            else
            {
                // Player loses!
                // EXPLODE SHIP AND FADE TO BLACK
                Debug.Log("DONE SHOOTING U DEAD");



                GameEventSystem.OnBossOver();
            }
        }
      

    }


    public override void Die()
    {

        Debug.Log("Enemy Died!");
        //GameEventSystem.current.EnemyDeath();

        Destroy(this.gameObject);

        BossEyeBattlerManager.OnKillLazer();

    }
    // states

    // 1. Idle
    // 2. Charging
    // 3. Shooting
    // 4. Damaged/Recovering

    //    public void LazorShake()
    //    {
    //      
    //        StartCoroutine(camShake.Shake(lazorShakeDuration, lazorShakeMaq));
    //  Debug.Log("Shakeeee");

    //   }

    public void StartBoss()
    {

        startBoss = true;

        idle_Timer = idleTime;
    }
}
