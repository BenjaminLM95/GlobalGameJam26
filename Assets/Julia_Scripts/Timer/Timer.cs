using UnityEngine;
using System.Collections;
using TMPro;
using System;
using Microsoft.Unity.VisualStudio.Editor;
using System.Collections.Generic;
using System.Globalization;

public class Timer : MonoBehaviour
{
    public float maxTime = 240f;
    private float currentTime;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Sprite[] numbers;
    private Dictionary<int, Sprite> timerNums;
    // if its bigger than 9
    // divide by 10 - first digit assigned
    // modulo 10 - second digit assigned 
    void Start()
    {
        currentTime = maxTime;
        timerNums = new Dictionary<int, Sprite>()
        {
            {0, (Sprite)numbers.GetValue(0)},
            {1, (Sprite)numbers.GetValue(1)},
            {2, (Sprite)numbers.GetValue(2)},
            {3, (Sprite)numbers.GetValue(3)},
            {4, (Sprite)numbers.GetValue(4)},
            {5, (Sprite)numbers.GetValue(5)},
            {6, (Sprite)numbers.GetValue(6)},
            {7, (Sprite)numbers.GetValue(7)},
            {8, (Sprite)numbers.GetValue(8)},
            {9, (Sprite)numbers.GetValue(9)},
        };
    }

    void Update()
    {
        if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerUI(currentTime);
        }
        else
        {
            currentTime = 0;
            TimerEnded();
        }
    }

    void UpdateTimerUI(float time)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        timerText.text = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
    }

    void TimerEnded()
    {
        Debug.Log("Time's up!");
        // game over logic (call event, change state)
    }

    // change sprite of text to number sprite
}
