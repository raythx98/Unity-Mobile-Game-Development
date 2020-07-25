using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensor : MonoBehaviour
{
    public float currentTime = 0f;
    public float startTime = 30f;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
        }

        if (GameObject.FindGameObjectsWithTag("enemy").Length == 0) 
        {
            int score = (int)(1000 + currentTime * 100);
            GameObject.Find("gameCanvas").GetComponent<GameManager>().WinGame(score, "Battle");
        }
    }
}
