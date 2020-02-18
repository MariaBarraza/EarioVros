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
	float dirX;

	[SerializeField]
	float jumpForce = 500f, moveSpeed = 5f;

	Rigidbody2D rb;

	bool doubleJumpAllowed = false;
	bool onTheGround = false;


  
    [SerializeField]
    int lives = 3;

    // Sound Effects
    public AudioClip moveSound1;
    public AudioClip moveSound2;
    public AudioClip gameOverSound;
    

    void Start()
    {
        
        gameManager = FindObjectOfType<GameManager>();
        gameManager.lastCheckPointPos = new Vector2(transform.position.x, transform.position.y);
    	rb = GetComponent<Rigidbody2D> ();

    }
    
    void FixedUpdate()
    {
        rb.velocity = new Vector2 (dirX, rb.velocity.y);
    }

    void Update()
    {
        GameplaySystem.TMovementDelta(transform, moveSpeed);
        		
		if (rb.velocity.y == 0)
			onTheGround = true;
		else
			onTheGround = false;
		
		if (onTheGround)
			doubleJumpAllowed = true;

		if (onTheGround && Input.GetButtonDown ("Jump")) {
			Jump ();
		} else if (doubleJumpAllowed && Input.GetButtonDown ("Jump")) {
			Jump ();
			doubleJumpAllowed = false;
		}
		
		dirX = Input.GetAxis ("Horizontal") * moveSpeed;

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
        Destroy(this.gameObject);
        // I still need to make the camera fadeOut
         //SoundManager.instance.PlaySingle(gameOverSound);
        //SoundManager.instance.musicSource.Stop();
    }
   public void Hit()
    {
         gameManager.UpdateLives(-1);
        this.transform.position = new Vector2(gameManager.lastCheckPointPos.x, gameManager.lastCheckPointPos.y);
        if(gameManager.lives<1)
        {   
            gameManager.UpdateLives(3);
            Death();    
        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Corazon"))
        {
             gameManager.AddHeart();
            Destroy(other.gameObject);
        }
        /*if(other.CompareTag("Enemy"))
        {
            GameManager.instance.UpdateLives(-1);
            Respawn();
        }*/
    }

    	void Jump()
	{
		rb.velocity = new Vector2 (rb.velocity.x, 0f);;
		rb.AddForce (Vector2.up * jumpForce);
	}

}


