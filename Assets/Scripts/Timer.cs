using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [Header("Component")] 
    public TextMeshProUGUI timertext;

    [Header("Timer Settings")]
    public float currentTime;

    public bool countDown;

    private float timerMinute;
    private float timerSeconds;
    
    
    
    
    // Update is called once per frame
    void Update()
    {
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;
        timerMinute = currentTime/60;
        timerSeconds = currentTime % 60;

        if ( timerMinute < 10 && timerSeconds < 10)
        {
            timertext.text = "Timer: 0" + timerMinute.ToString("0") + ":0" + timerSeconds.ToString("0");
        }
        if (timerMinute < 10 && timerSeconds > 10)
        {
            timertext.text = "Timer: 0" + timerMinute.ToString("0") + ":" + timerSeconds.ToString("0");
        }
        if (timerMinute > 10 && timerSeconds < 10)
        {
            timertext.text = "Timer: " + timerMinute.ToString("0") + ":0" + timerSeconds.ToString("0");
        }
        if (timerMinute > 10 && timerSeconds > 10)
        {
            timertext.text = "Timer: " + timerMinute.ToString("0") + ":" + timerSeconds.ToString("0");
        }
    }
}
