using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public GameObject endMenu;
    public SceneSwitcher sceneSwitcher;
    public Timer gameTimer;

    void Start()
    {
        Time.timeScale = 1f;
    } 
    
    void FixedUpdate()
    {
        if (gameTimer.isDone())
        {
            Time.timeScale = 0f;
            endMenu.SetActive(true);
        }
    }
}
