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


    private void Start()
    {
        OnGameStart();
    }
}
