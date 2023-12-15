using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public GameObject endMenu;
    public SceneSwitcher sceneSwitcher;
    public Timer gameTimer;
    
    void FixedUpdate()
    {
        if (gameTimer.isDone())
        {
            Time.timeScale = 0f;
            endMenu.SetActive(true);
        }
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        sceneSwitcher.RestartScene();
    }
}
