using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class GameEventSystem : MonoBehaviour
{
    public static event UnityAction PlayerDeath;

    public static void OnPlayerDeath() => PlayerDeath?.Invoke();


    public static event UnityAction GameStart;

    public static void OnGameStart() => GameStart?.Invoke();

    public static event UnityAction IncreaseCheckpoint;

    public static void OnIncreaseCheckpoint() => IncreaseCheckpoint?.Invoke();


    public static event UnityAction RespawnPlayer;

    public static void OnRespawnPlayer() => RespawnPlayer?.Invoke();



    private void Start()
    {
        OnGameStart();
    }
}
