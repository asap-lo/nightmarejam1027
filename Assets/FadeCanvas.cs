using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCanvas : MonoBehaviour
{

    public Animator anim;

    bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        gameObject.SetActive(true);

        GameEventSystem.PlayerDeath += FadeOut;
        GameEventSystem.BossOver += FadeOut;
        GameEventSystem.GameStart += FadeIn;

        GameEventSystem.RespawnPlayer += FadeIn;

    }


    private void OnDestroy()
    {
        GameEventSystem.PlayerDeath -= FadeOut;
        GameEventSystem.BossOver -= FadeOut;
        GameEventSystem.GameStart -= FadeIn;

        GameEventSystem.RespawnPlayer -= FadeIn;

    }

    void FadeOut()
    {
        if (!gameOver)
        {
            anim.SetTrigger("FadeOut");
            gameOver = true;
        }
        
    }


    void FadeIn()
    {
        anim.SetTrigger("FadeIn");
        gameOver = false;
    }

}
