using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEye : Enemy
{


    public float idleTime;
    public float lazorChargingTime;
    public float shootingTime;
    public float recoveryTime;



    [Header("Debug")]
    public float idle_Timer;
    public float lazorCharging_Timer;
    public float shooting_Timer;
    public float recovery_Timer;

    public states currentState;

    public enum states
    {
        Idle,
        Charging,
        Shooting,
        Damaged
    }

    private Animator anim;
    
        private void Start()
    {
        anim = GetComponent<Animator>();


        idle_Timer = idleTime;
         lazorCharging_Timer = lazorChargingTime;
         shooting_Timer = shootingTime;
         recovery_Timer = recoveryTime;

}



    private void Update()
    {

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
            }
        }
        else if (currentState == states.Damaged)
        {
            // play damaged/recovery animation (sway back and forth??)
            // count down from recoveryTimer

            //transition to idle or wait for next wave ??

            if (recoveryTime > 0)
            {
                recoveryTime -= Time.deltaTime;
            }
            else
            {


            }

        }




    }



    // states

    // 1. Idle
    // 2. Charging
    // 3. Shooting
    // 4. Damaged/Recovering


}
