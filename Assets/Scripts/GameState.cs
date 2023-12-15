using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public SceneSwitcher sceneSwitcher;
    public Timer gameTimer;
    
    void FixedUpdate()
    {
        if (gameTimer.isDone())
        {
            Time.timeScale = 0f;
        }
    }

    void Update()
    {
        
    }
}
