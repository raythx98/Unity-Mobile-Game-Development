using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensor : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("enemy").Length == 0) 
        {
            GameObject.Find("gameCanvas").GetComponent<GameManager>().WinGame();
        }
    }
}
