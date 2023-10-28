using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetButton("Jump"))
        {
            animator.SetTrigger("PlayerInteraction"); // Next... Lock movement, make it so player can only attack.

        }
    }

    public void MobilizePlayer() { }
}
