using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Platform2DUtils.GameplaySystem;
using UnityEngine.SceneManagement;

public class Player : Character2D
{
    private GameManager gameManager;

    // Spawn point of the player
    private Vector2 spawnPoint;

    Animator anim;
    
    SpriteRenderer sprite;

    // Double Jump
    float dirX;

    [SerializeField]
    float jumpForce = 800f, moveSpeed = 5f;

    Rigidbody2D rb;

    bool doubleJumpAllowed = false;

    [SerializeField]
    int lives = 3;

    // Sound Effects
    public AudioClip jumpSound;
    public AudioClip deathSound;
    public AudioClip gameOverSound;

    private bool invincible = false;

    [SerializeField] float invincibilityTime = 1.0f;
    
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.lastCheckPointPos = new Vector2(transform.position.x, transform.position.y);
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX, rb.velocity.y);
        // GameplaySystem.TMovementDelta(transform, moveSpeed);
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (rb.velocity.y < 0.05f && rb.velocity.y > -0.05f)
            {
                Jump();
                doubleJumpAllowed = true;
                anim.SetBool("grounding", false);
            }
            else if (doubleJumpAllowed)
            {
                Jump();
                doubleJumpAllowed = false;
                anim.SetBool("grounding", false);
            }
        }

        if (Grounding)
        {
            anim.SetBool("grounding", true);
        }

        dirX = Input.GetAxis("Horizontal") * moveSpeed;

        // Sends the value from the horizontal axis input to the animator. Change the settings in the
        // Animator to define when the character is walking or running
        anim.SetFloat("moveX", Mathf.Abs(dirX));
    }

    void LateUpdate()
    {
        spr.flipX = FlipSprite;
    }

    /// <summary>
    /// Fades the camera to the death screen and stops the music.
    /// </summary>
    void Death()
    {
        gameManager.lastCheckPointPos = gameManager.initialPosition;
        gameManager.dead = true;
        gameManager.GameOver();
        Destroy(this.gameObject);

        // I still need to make the camera fadeOut
        //SoundManager.instance.PlaySingle(gameOverSound);
        //SoundManager.instance.musicSource.Stop();
    }
    
    public void Hit()
    {
        // anim.SetBool("death", true);
        if (gameManager.lives < 2)
        {
            gameManager.UpdateLives(-1);
            Death();
        }
        if (!invincible)
        {
            gameManager.UpdateLives(-1);
            
            respawn();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Corazon"))
        {
            gameManager.AddHeart();
            Destroy(other.gameObject);
        }
    }

    IEnumerator resetInvulnerability()
    {
        yield return new WaitForSeconds(invincibilityTime);
        invincible = false;
    }

    void respawn()
    {
        invincible = true;

        // yield return new WaitForSeconds(0.2f);

        this.transform.position = new Vector2(gameManager.lastCheckPointPos.x, gameManager.lastCheckPointPos.y);

        // Set animation back to Idle
        // anim.SetBool("death", false);
        StartCoroutine(resetInvulnerability());
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0.0f);
        rb.AddForce(Vector2.up * jumpForce);
    }
}
