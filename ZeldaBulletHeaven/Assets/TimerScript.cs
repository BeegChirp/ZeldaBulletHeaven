using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float secondsCount;
    private int minuteCount;
    private int hourCount;
    private string minuteZero;
    private string secondZero;
    void Start()
    {
        secondsCount = 0;
        minuteCount = 0;
        hourCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimerUI();
    }
    public void UpdateTimerUI()
    {
        secondsCount += Time.deltaTime;
        while (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = secondsCount - 60;
        }
        while (minuteCount >= 60)
        {
            hourCount++;
            minuteCount = minuteCount - 60;
        }
        if (secondsCount < 10) secondZero = "0";
        else secondZero = "";
        if (minuteCount < 10) minuteZero = "0";
        else minuteZero = "";

        if (hourCount > 0) timerText.text = hourCount + ":" + minuteZero + minuteCount + ":" + secondZero + (int)secondsCount;
        else timerText.text = minuteZero + minuteCount + ":" + secondZero + (int)secondsCount;
    }
}
