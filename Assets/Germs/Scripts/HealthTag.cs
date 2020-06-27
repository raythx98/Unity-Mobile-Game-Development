using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthTag : MonoBehaviour
{
    public EnemyHealth enemyHealth;

    // Update is called once per frame
    void Update()
    {
        Vector2 healthPos = Camera.main.WorldToScreenPoint(this.transform.position);
        enemyHealth.transform.position = healthPos;
    }
}
