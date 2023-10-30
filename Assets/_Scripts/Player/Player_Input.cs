using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Input : MonoBehaviour
{
    public KeyCode attackKey;
    public Player_Motor player_Motor;

    [Header("Debug")]
    public bool EnableInput = true;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Start()
    {
        enableInput();
        GameEventSystem.current.onPauseGame += disableInput;
        GameEventSystem.current.onResumeGame += enableInput;

    }

    private void OnValidate()
    {
        player_Motor = GetComponent<Player_Motor>();
      
    }

    private void Update()
    {
        //If accepting input
        if (EnableInput)
        {
          

            //get arrow key input float
            player_Motor.inputDir.x = Input.GetAxisRaw("Horizontal");
            player_Motor.inputDir.y = Input.GetAxisRaw("Vertical");

        }
        else //If cannot input -> dont move
        {
            //this is done to fix a bug then when disabled, the player motor will use the last values of InputDir
            player_Motor.inputDir.x = 0;
            player_Motor.inputDir.y = 0;
        }
    }


    void disableInput()
    {
        EnableInput = false;
    }
    void enableInput()
    {
        EnableInput = true;
    }
}
