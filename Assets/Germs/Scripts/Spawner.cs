using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject sawObject;
    public int yPos; //-3.52, 4.49
    public int xPos; //-8.42, 8.42
    public int enemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop() 
    {
        while (enemyCount < 5)
        {
            yPos = Random.Range(-5, 7);
            xPos = Random.Range(0, 2);
        
            if (xPos == 0) // from left
            {
                Instantiate(sawObject, new Vector3(-12.53f, yPos, 0), Quaternion.identity);
            }
            else // from right
            {
                Instantiate(sawObject, new Vector3(12.53f, yPos, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(1.0f);
            enemyCount += 1;
        }
    }
}
