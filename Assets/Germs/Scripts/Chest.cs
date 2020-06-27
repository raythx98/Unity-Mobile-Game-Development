using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject chestObj;

    public Animator animator;

    public int maxHealth = 3;
    int currentHealth;
    private bool isOpened = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(int damage)
    {
        if (!isOpened)
        {
            currentHealth -= 1;
        }

        if (currentHealth == 1){
            animator.SetBool("isOpened", true);

            //play sound of opened chest
            FindObjectOfType<AudioManager>().Play("ChestOpen");
        }

        // check if opened
        if (currentHealth <= 0 && !isOpened)
        {
            isOpened = true;
            Destroy(chestObj);
        }
    }
}
