using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnRange : MonoBehaviour
{
    public GameObject activate;
    public LayerMask layerMask;
    private Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((layerMask.value & (1 << collision.gameObject.layer)) > 0 )
        {
            activate.SetActive(true);
            animator.SetTrigger("Open");
        }
        GameObject.Destroy(gameObject, 1.1f);
    }

}
