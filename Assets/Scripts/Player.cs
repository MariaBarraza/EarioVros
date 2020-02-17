using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Platform2DUtils.GameplaySystem;
using UnityEngine.SceneManagement;

public class Player : Character2D
{   
    private GameManager gameManager;
    // Spawn point of the player
    private Vector2 spawnPoint;


    // Double Jump
    bool doubleJump = true;

  
    [SerializeField]
    int lives = 3;

    // Sound Effects
    public AudioClip moveSound1;
    public AudioClip moveSound2;
    public AudioClip jumpSound;
    public AudioClip gameOverSound;
    
    private bool invincible = false;
    
    [SerializeField] float invincibilityTime = 1.0f;

    void Start()
    {
        
        gameManager = FindObjectOfType<GameManager>();
        gameManager.lastCheckPointPos = new Vector2(transform.position.x, transform.position.y);
    }
    
    void FixedUpdate()
    {
        if(GameplaySystem.JumpBtn)
        {
             if (Grounding) 
             {
                // anim.SetTrigger("jump");
                GameplaySystem.Jump(rb2D, jumpForce);
                doubleJump = true;
             }else {
                if (doubleJump) 
                {
                // anim.SetTrigger("jump2");
                GameplaySystem.Jump(rb2D, (jumpForce));
                doubleJump = false;
                }
            }
        //anim.SetBool("grounding", Grounding);
         }
    }

    void Update()
    {
        GameplaySystem.TMovementDelta(transform, moveSpeed);
    }

    void LateUpdate()
    {
        spr.flipX = FlipSprite;
        //anim.SetFloat("axisX", Mathf.Abs(GameplaySystem.Axis.x));
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
    }
   public void Hit()
    {
        if(gameManager.lives<2)
        {  
            gameManager.UpdateLives(-1);
            Death();

            SoundManager.instance.PlaySingle(gameOverSound);
            SoundManager.instance.musicSource.Stop();
        }
        if(!invincible)
        {
            gameManager.UpdateLives(-1);
            this.transform.position = new Vector2(gameManager.lastCheckPointPos.x, gameManager.lastCheckPointPos.y);
            invincible = true;
            StartCoroutine(resetInvulnerability());

            SoundManager.instance.PlaySingle(gameOverSound);
            SoundManager.instance.musicSource.Stop();
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Corazon"))
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
}
