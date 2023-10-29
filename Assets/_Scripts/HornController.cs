using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornController : MonoBehaviour
{
    public bool ready;
    private Animator animator;
    public LayerMask hitbox;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ready)
            if ((hitbox.value & (1 << collision.gameObject.layer)) > 0) // Change to the hitbox for pickaxe mask thing
            {
                animator.SetTrigger("Success");
                animator.SetInteger("Count", animator.GetInteger("Count") + 1);
            }
    }
}
