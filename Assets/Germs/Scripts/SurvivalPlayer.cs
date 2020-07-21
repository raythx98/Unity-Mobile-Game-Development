using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class SurvivalPlayer : MonoBehaviour
{
    public float moveSpeed, jumpHeight;
    public bool onGround = false;
    public Animator animator;
    float horizontalMove = 0f;

    // determine which way player is facing
    private bool faceRight = true;

    // for health bar
    [Header("Health Bar")]
    public int maxHealth = 100;
    int currentHealth;
    public HealthBar healthBar;
    public bool isAlive = true;

    // for damage screen
    [Header("Damage Screen")]
    public Color damageColor;
    public Image damageImage;
    float colorSmoothing = 0.5f;
    bool damageTaken = false;

    // Start is called before the first frame update
    void Start()
    {
        // set health bar
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // to move
        horizontalMove = CrossPlatformInputManager.GetAxis("Horizontal") * moveSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
        // face direction of movement
        if (horizontalMove > 0)
        {            
            if (!faceRight)
            {
                Flip();
            }
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        }
        else if (horizontalMove < 0)
        {
            if (faceRight)
            {
                Flip();
            }
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        }

        // to jump
        if (CrossPlatformInputManager.GetButtonDown("Jump") && onGround) 
        {
            animator.SetBool("isJumping", true);
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            onGround = false; // solved inconsistent jump height
        }

        // to display damage screen
        if (damageTaken)
        {
            damageImage.color = damageColor;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, colorSmoothing * Time.deltaTime);
        }
        damageTaken = false;
    }

    void Flip() 
    {
        faceRight = !faceRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    // to disable double jumping
    void OnCollisionEnter2D (Collision2D obj)
    {
        if (obj.gameObject.tag == "ground")
        {
            FindObjectOfType<AudioManager>().Play("PlayerLand");
            animator.SetBool("isJumping", false); // stop jumping animation
            onGround = true;
        } 
    }

    void OnCollisionExit2D (Collision2D obj)
    {
        if (obj.gameObject.tag == "ground")
        {
            onGround = false; // disallow jumping in air
        }
    }

    public void takeDamage(int damage)
    {
        damageTaken = true;
        currentHealth -= damage;
        // update health bar
        healthBar.SetHealth(currentHealth);

        //play hurt animation
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // player died
        animator.SetBool("isDead", true);
        isAlive = false;

        FindObjectOfType<AudioManager>().Play("PlayerDeath");
        
        this.enabled = false;

        GameObject.Find("Countdown").GetComponent<SurvivalTimer>().lost = true;
        GameObject.Find("LeftSpawner").GetComponent<Spawner>().lost = true;
        GameObject.Find("RightSpawner").GetComponent<Spawner>().lost = true;

        GameObject.Find("gameCanvas").GetComponent<GameManager>().LoseGame();
    }
}
