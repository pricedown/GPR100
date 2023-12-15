using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI display;
    private int score;

    public int getScore()
    {
        return score; 
    }

    public void addScore(int delta)
    {
        score += delta;
        display.text = score.ToString();
    }
}
