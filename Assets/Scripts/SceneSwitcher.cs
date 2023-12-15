using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    private int thisSceneIndex;
    private int sceneListCount;

    private void Awake()
    {
        thisSceneIndex = SceneManager.GetActiveScene().buildIndex; 
        sceneListCount = SceneManager.sceneCountInBuildSettings;
    }

    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }
    
    public void LoopScene()
    {
        SceneManager.LoadScene((thisSceneIndex + 1) % sceneListCount);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(thisSceneIndex);
    }

    public void ExitGame()
    {
        Debug.Log("Exiting game, goodbye!");
        Application.Quit();
    }


}
