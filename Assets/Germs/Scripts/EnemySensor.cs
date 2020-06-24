using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySensor : MonoBehaviour
{
    public Transform midPoint;
    public LayerMask enemies;
    public float range = 1f;

    // Update is called once per frame
    void Update()
    {
        Collider2D[] enemiesAlive = Physics2D.OverlapCircleAll(midPoint.position, range, enemies);

        if (enemiesAlive.Length == 0) 
        {
            GameObject.Find("gameCanvas").GetComponent<GameManager>().WinGame();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(midPoint.position, range);
    }
}
