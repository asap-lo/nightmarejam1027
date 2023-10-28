using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TarodevController;
public class Player_Attack : MonoBehaviour
{

    public Collider2D attackCollider;
    public KeyCode attackButton;

    public int attackDamage = 1;
    public float attackKnockback = 1;

    public float attackDelay = 1f;
    public float attackDuration = 0.1f;
    
   
    [Header("Debug")]
    public bool canAttack = true;
    public bool _grounded;
    public float durationTimer;
    public float delayTimer;

    PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        pc = GetComponent<PlayerController>();

        attackCollider.gameObject.SetActive(false);
        durationTimer = attackDuration;
        delayTimer = attackDelay;
        pc.GroundedChanged += OnGroundedChanged;
    }

    // Update is called once per frame
    void Update()
    {

        if (delayTimer > 0)
        {


            delayTimer -= Time.deltaTime;
        }
        else
        {
            if (Input.GetKeyDown(attackButton))
            {
                if (canAttack && !_grounded)
                {
                    Attack();
                }

            }
        }

       


        if (durationTimer > 0)
        {
             canAttack = false; //dont double attack

            durationTimer -= Time.deltaTime;
        }
        else
        {
            //stop attack
            canAttack = true;

            attackCollider.gameObject.SetActive(false);
        }
    


        
    }


    public void OnTriggerEnter2DChild(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            Debug.Log("Hit Enemy");

            collision.gameObject.GetComponent<Enemy>().TakeDamange(attackDamage, this.transform, attackKnockback);
            pc.ExecutePickJump();
        }
    }

    

    void Attack()
    {
        durationTimer = attackDuration;
        delayTimer = attackDelay;

        attackCollider.gameObject.SetActive(true);
        pc.ExecuteCustomJump(5);

    }



    private void OnGroundedChanged(bool grounded, float impact)
    {
        _grounded = grounded;
       
    }

}
