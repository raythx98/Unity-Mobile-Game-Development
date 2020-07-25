using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject sawObject;
    public int yPos; 
    public int xPos; 
    public int enemyCount = 0;
    public bool left;
    private GameObject saw;
    public bool lost = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    void Update()
    {
        if (lost)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator EnemyDrop() 
    {
        while (enemyCount < Mathf.Infinity)
        {
            yPos = Random.Range(-5, 7);

            if (left) // from left
            {
                saw = Instantiate(sawObject, new Vector3(-12.7f, yPos, 0), Quaternion.identity);
            }
            else // from right
            {
                saw = Instantiate(sawObject, new Vector3(12f, yPos, 0), Quaternion.identity);
            }
            yield return new WaitForSeconds(0.5f);
            Destroy(saw, 2f);
            enemyCount += 1;
        }
    }
}
