using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EagleGFX : MonoBehaviour
{
    public AIPath aiPath;
    
    // for animation
    public Animator animator;

    // for attack
    public Transform player;
    public MovementManager playerMovement;
    public Transform attackPoint;
    public float attackRange = 1f;
    public int attackDamage = 5;
    public float senseRange = 2f;
    public LayerMask players;
    public float attackRate = 0.5f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        // to face moving direction
        if (aiPath.desiredVelocity.x >= 0.01f) 
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        } else if (aiPath.desiredVelocity.x <= 0.01f) 
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        // to delay enemy attack rate
        if (Time.time >= nextAttackTime)
        {
            if (Vector3.Distance(player.position, transform.position) <= senseRange && (playerMovement.isAlive))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, players);

        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<MovementManager>().takeDamage(attackDamage);
        }        
    }
}
