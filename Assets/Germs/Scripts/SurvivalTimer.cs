using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SurvivalTimer : MonoBehaviour
{
    float currentTime = 0f;
    float startTime = 0f;
    public bool lost = false;

    public TextMeshProUGUI countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!lost)
        {
            currentTime += 1 * Time.deltaTime;
            countdownText.text = currentTime.ToString("F2");
        }
        else
        {
            this.enabled = false;
        }
    }
}
