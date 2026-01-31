using UnityEngine;
using System.Collections;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public float maxTime = 240f;
    private float currentTime;
    [SerializeField] private TextMeshProUGUI timerText;

    void Start()
    {
        currentTime = maxTime;
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
}
