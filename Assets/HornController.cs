using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HornController : MonoBehaviour
{
    public bool ready;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (ready)
            if (collision != null) // Change to the player mask thing
                return; //Do success trigger
    }
}
