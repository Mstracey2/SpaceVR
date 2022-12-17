using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    #region Variables
    private TMP_Text timer;                     //reference of timer text
    public float countDownFloat = 300;         //float set to 5 mins
    private bool activated = false;
    #endregion

    #region Get Component
    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<TMP_Text>(); 
    }
    #endregion

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            countDownFloat -= Time.deltaTime;           //starts counting down
        }
        if(countDownFloat <= 0)
        {
            countDownFloat = 0;
            activated = false;
        }
        
        displayTime(countDownFloat);                // function that displays the time in minutes
    }

    void displayTime(float TimeToDisplay)
    {
        float minutes = Mathf.FloorToInt(TimeToDisplay / 60);           //divides the value by 60 to get the minutes, rounds to the nearest whole number
        float seconds = Mathf.FloorToInt(TimeToDisplay % 60);           // returns the remainder value as the seconds

        timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);  // layers the text correctly
    }

    public void Active(bool status)
    {
        activated = status;
    }

    public float CheckTimer()
    {
        return countDownFloat;
    }
}
