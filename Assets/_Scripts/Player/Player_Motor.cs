using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Motor : MonoBehaviour
{
    [Header("Stats")]
    public float baseSpeed = 2;


    [Header("Component References")]
    public SpriteRenderer playerSpriteRenderer; //have to make hard refenerence due to the player hierarchy


    [Header("Debug")]
    public Vector2 inputDir = new Vector2();
    public bool canMove = true;


    private Rigidbody2D rb;
    private Animator anim;
    private Player_Input input;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
       // anim = GetComponentInChildren<Animator>();
        input = GetComponent<Player_Input>();
    }


    void Update()
    {
        HandleAnimation();

    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            Move();
        }
    }

    public void Move()
    {
        rb.MovePosition(rb.position + (inputDir.normalized * baseSpeed) * Time.deltaTime);
    }

    private void HandleAnimation()
    {
        if (inputDir != Vector2.zero)
        {
            //anim.SetFloat("Horizontal", inputDir.x);
            //anim.SetFloat("Vertical", inputDir.y);
            inputDir.Normalize();
            if (inputDir.x != 0)
            {
                // playerSpriteRenderer.flipX = inputDir.x < 0;
                if (inputDir.x < 0)
                {
                    playerSpriteRenderer.transform.localScale = new Vector3(-1, 1, 0);

                }
                else
                    playerSpriteRenderer.transform.localScale = new Vector3(1, 1, 0);
            }

        }

       // anim.SetFloat("Input", inputDir.sqrMagnitude);
    }

    public void FreezePlayer()
    {
        canMove = false;
    }


    public void UnfreezePlayer()
    {

        canMove = true;
    }

}
