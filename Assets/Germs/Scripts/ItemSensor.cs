using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ItemSensor : MonoBehaviour
{
    public int score = 0;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("item").Length == 0
        && GameObject.FindGameObjectsWithTag("gem").Length == 0) 
        {
            float current = GameObject.Find("Countdown").GetComponent<CountdownTimer>().currentTime;
            float end = GameObject.Find("Countdown").GetComponent<CountdownTimer>().startTime;
            int coinRemain = GameObject.FindGameObjectsWithTag("item").Length;
            int gemRemain = GameObject.FindGameObjectsWithTag("gem").Length;
            score = (int)(current/end * 2000 + (7 - coinRemain) * 100 + (1 - gemRemain) * 1000);

            GameObject.Find("Countdown").GetComponent<CountdownTimer>().win = true;
            GameObject.Find("gameCanvas").GetComponent<GameManager>().WinGame(score, "Treasure");
        }
    }
}
