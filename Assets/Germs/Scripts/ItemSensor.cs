using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSensor : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("item").Length == 0
        && GameObject.FindGameObjectsWithTag("gem").Length == 0) 
        {
            GameObject.Find("gameCanvas").GetComponent<GameManager>().WinGame();
        }
    }
}
