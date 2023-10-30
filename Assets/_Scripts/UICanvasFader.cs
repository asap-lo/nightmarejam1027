using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CanvasGroup))]
public class UICanvasFader : MonoBehaviour
{

    [SerializeField]
    [Tooltip("Seconds it takes to fade in or out")]
    private float timeToFade = 1;

    CanvasGroup canvasGroup;

    public float startingAlpha = 0;
    private void Awake()
    {

        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = startingAlpha;
    }

    void Start()
    {
//        GameEventSystem.current.onStartMenu += FadeIn;
  //      GameEventSystem.current.onPlayGame += FadeOut;
    }
    public void FadeIn()
    {
        Debug.Log("Fade IN");
        StartCoroutine(FadeCanvas(1));
    }

    public void FadeOut()
    {
        Debug.Log("Fade Out");
        StartCoroutine(FadeCanvas(0));
    }


    IEnumerator FadeCanvas(float targetAlpha)
    {
        float elapsedTime = 0;
        float startAlpha = canvasGroup.alpha;

        while (elapsedTime < timeToFade) //will fade for timeToFade seconds
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, (elapsedTime / timeToFade));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        yield return null; //done
    }



}
