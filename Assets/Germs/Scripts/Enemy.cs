using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // for animation
    public Animator animator;

    // for health bar
    public int maxHealth = 100;
    int currentHealth;
    public EnemyHealth healthBar;
    private bool isDead = false;

    // to store player and face player direction
    public Transform player;
    private float distance;
    public MovementManager playerMovement;

    // for attack
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public float senseRange = 2f;
    public LayerMask players;
    public float attackRate = 0.5f;
    float nextAttackTime = 0f;

    public bool facingLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        // set health bar
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        // to delay enemy attack rate
        if (Time.time >= nextAttackTime)
        {
            if (Vector3.Distance(player.position, transform.position) <= senseRange && (playerMovement.isAlive))
            {
                Attack();
                FindObjectOfType<AudioManager>().Play("EnemySword");
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        // to check and face player direction
        distance = transform.position.x - player.transform.position.x;

        if (distance < 0)
        {
            if (facingLeft)
            {
                Flip();
                facingLeft = false;
            }
        }
        else
        {
            if (!facingLeft)
            {
                Flip();
                facingLeft = true;
            }
        }
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

    public void Flip() 
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, players);

        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<MovementManager>().takeDamage(attackDamage);
        }        
    }
    
    void Die()
    {
        // enemy died
        animator.SetBool("isDead", true);

        FindObjectOfType<AudioManager>().Play("EnemyKilled");

        this.enabled = false;
        GameObject.Find("gameCanvas").GetComponent<GameManager>().WinGame();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
