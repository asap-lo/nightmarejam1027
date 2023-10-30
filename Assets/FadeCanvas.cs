using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeCanvas : MonoBehaviour
{

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        GameEventSystem.PlayerDeath += FadeOut;
        GameEventSystem.GameStart += FadeIn;
    }

   


    void FadeOut()
    {
        anim.SetTrigger("FadeOut");
    }


    void FadeIn()
    {
        anim.SetTrigger("FadeIn");
    }

}
