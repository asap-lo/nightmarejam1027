using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    //public Animator anim;

    private string levelToLoad;
   
    private void Awake()
    {
        //anim = GetComponent<Animator>();
       // OnLevelLoad?.Invoke();
    }

    //public void FadeToLevel(string sceneName)
    //{
    //    ResumeGame();
    //    levelToLoad = sceneName;
    //    anim.SetTrigger("FadeOut");
    //}

    //public void OnFadeComplete()
    //{
    //    SceneManager.LoadScene(levelToLoad);
    //}

    public static void loadScene(string sceneName)
    {
        ResumeGame();
        SceneManager.LoadScene(sceneName);
    }
    public static void loadGameScene()
    {
       SceneManager.LoadScene("Game Scene");
    }

    public static void quitApplication()
    {
        Application.Quit();
    }

    public static void PauseGame()
    {
        Time.timeScale = 0;
    }
    public static void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
