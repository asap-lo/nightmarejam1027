using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameEventSystem : MonoBehaviour
{
    public static GameEventSystem current;

    private void Awake()
    {
        current = this;
    }


    public event Action onStartMenu;
    public void StartMenu()
    {
        Debug.Log("Start  asdasdmnenu");
        if (onStartMenu != null)
        {
            onStartMenu();

            Debug.Log("Startmnenu");
        }
    }



    public event Action onPlayGame;
    public void PlayGame()
    {
        if (onPlayGame != null)
        {
            onPlayGame();
        }
    }



    public event Action onStartGame;
    public void StartGame()
    {
        if (onStartGame != null)
        {
            onStartGame();
        }
    }


    public event Action onRestartCheckpoint;
    public void RestartCheckpoint()
    {
        if (onRestartCheckpoint != null)
        {
            onRestartCheckpoint();
        }
    }

    public event Action onPlayerDeath;
    public void PlayerDeath()
    {
        if (onPlayerDeath != null)
        {
            onPlayerDeath();
        }
    }


    public event Action onPauseGame;
    public void PauseGame()
    {
        if (onPauseGame != null)
        {
            onPauseGame();
        }
    }



    public event Action onResumeGame;
    public void ResumeGame()
    {
        if (onResumeGame != null)
        {
            onResumeGame();
        }
    }

}
