using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    // Create variables
    public int timeLeft = 3;
    public Text countdownText;
    private bool running = false;
	protected int fontsize = 160;

    // Use this for initialization
    void Start()
    {
        StartCoroutine("LoseTime");             //coroutine method
        Time.timeScale = 1;                     //make sure scale is 1
    }

    // Update is called once per frame
    void Update()
    {
        if (!running)
        {
            countdownText.text = ("" + timeLeft);  //display it on the screen 
			countdownText.fontSize -= 3;
        }

        // if time = 0, display "go!"
        if (timeLeft <= 0 && !running)
        {
            StopCoroutine("LoseTime");
            countdownText.text = "Go!";
			GameManager.Instance.onStart();
        }

    }

    IEnumerator LoseTime()                      //coroutine method for count down time
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;                         //count down time
			countdownText.fontSize = fontsize;
        }
    }
}