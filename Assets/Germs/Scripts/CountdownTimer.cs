using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startTime = 50f;
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

        if (currentTime <= 0)
        {
            countdownText.text = "0.00";
            End();
        }
    }

    void End() {
        this.enabled = false;
        GameObject.Find("gameCanvas").GetComponent<GameManager>().LoseGame();
    }
}
