using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack_Collider : MonoBehaviour
{

    Player_Attack pa;
    // Start is called before the first frame update
    void Start()
    {
        pa = GetComponentInParent<Player_Attack>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        pa.OnTriggerEnter2DChild(collision);
    }
}
