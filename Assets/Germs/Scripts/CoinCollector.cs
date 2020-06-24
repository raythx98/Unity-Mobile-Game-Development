using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCollector : MonoBehaviour
{
    private float noOfCoins = 0f;

    public TextMeshProUGUI coinsText;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.tag == "item") {
            noOfCoins ++;
            coinsText.text = noOfCoins.ToString();

            Destroy(other.gameObject);
            FindObjectOfType<AudioManager>().Play("EnemyKilled");
        }
    }
}
