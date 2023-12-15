using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float durationSeconds = 60f;
    public TextMeshProUGUI display;
    [SerializeField]
    private float countDown;
    private bool counting = false;
    
    void Start()
    {
        countDown = durationSeconds;
        counting = true;
    }

    void FixedUpdate()
    {
        if (counting)
        {
            countDown -= Time.fixedDeltaTime;
            if (countDown <= 0f)
            {
                // TODO: end the run
                countDown = 0f;
            }
        }
    }

    void Update()
    {
        if (counting)
        {
            display.text = countDown.ToString("F0");
        }
    }
    
}
