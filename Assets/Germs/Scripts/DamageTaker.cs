using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class DamageTaker : MonoBehaviour
{

    public GameObject enemyObj;

    // for animation
    public Animator animator;

    // for health bar
    public int maxHealth = 100;
    int currentHealth;
    public EnemyHealth healthBar;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        // set health bar
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void takeDamage(int damage)
    {
        if (!isDead)
        {
            currentHealth -= damage;
            // update health bar
            healthBar.SetHealth(currentHealth);

            // play hurt animation
            animator.SetTrigger("Hurt");
        }

        // check if dead
        if (currentHealth <= 0 && !isDead)
        {
            Die();
            isDead = true;
        }
    }

    void Die()
    {
        // enemy died
        animator.SetBool("isDead", true);

        FindObjectOfType<AudioManager>().Play("EnemyKilled");
        Destroy(enemyObj);
    }
}