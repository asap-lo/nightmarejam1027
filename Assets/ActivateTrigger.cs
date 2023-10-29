using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTrigger : MonoBehaviour
{

    public GameObject attack_Collider;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableCollider()
    {
        attack_Collider.SetActive(true);
    }

    public void DisableCollider()
    {
        attack_Collider.SetActive(false);
    }
}
