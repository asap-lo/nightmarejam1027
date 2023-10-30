using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testEvent : MonoBehaviour
{

    public bool fireEvent = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (fireEvent)
        {
            BossEyeBattlerManager.OnStartBoss();
 
            Debug.Log("FIRINGs");
        }
    }
        
    
}
