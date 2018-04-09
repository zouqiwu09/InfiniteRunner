﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    // Create variables
    public int timeLeft = 3;
    public Text countdownText;


    // Use this for initialization
    void Start()
    {
        StartCoroutine("LoseTime");             //coroutine method
        Time.timeScale = 1;                     //make sure scale is 1
    }

    // Update is called once per frame
    void Update()
    {
        countdownText.text = ("" + timeLeft);  //display it on the screen 
        
        // if time = 0, display "go!"
        if (timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            countdownText.text = "Go!";
        }

        // if press W, text should disappear
        // doesn't work
        if (Input.GetKeyDown(KeyCode.W))
        {
            countdownText.text = "";
        }

    }

    IEnumerator LoseTime()                      //coroutine method for count down time
    {
        while (true)
        {
            yield return new WaitForSeconds (1);
            timeLeft--;                         //count down time
        }
    }
}