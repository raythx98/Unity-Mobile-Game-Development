using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public float currentTime = 0f;
    public float startTime = 20f;
    public bool win = false;

    public TextMeshProUGUI countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!win)
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("F2");
        }

        if (currentTime <= 0f)
        {
            countdownText.text = "0.00";
            End();
        }
    }

    void End() {
        this.enabled = false;
        int coinRemain = GameObject.FindGameObjectsWithTag("item").Length;
        int gemRemain = GameObject.FindGameObjectsWithTag("gem").Length;
        GameObject.Find("gameCanvas").GetComponent<GameManager>().LoseGame((7-coinRemain)*100 + (1-gemRemain)*1000, "Treasure");
    }
}
