using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Platform2DUtils.GameplaySystem;

public class Player : Character2D
{   
    // Spawn point of the player
    private Vector2 spawnPoint;

    // Double Jump
    bool doubleJump = false;

    // Sound Effects
    public AudioClip moveSound1;
    public AudioClip moveSound2;
    public AudioClip gameOverSound;

    void Start()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            GameManager.instance.GameData = SaveSystem.LoadGameState();

            GameManager.instance.Player = gameObject; 

            GameManager.instance.PlayerPos = new Vector3(
                GameManager.instance.GameData.position[0],
                GameManager.instance.GameData.position[1]
            );

            GameManager.instance.Player.transform.position = GameManager.instance.PlayerPos;
        } else {
            Debug.Log("Save file not found in " + path);
        }
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
    /// Returns the player to its starting position.
    /// </summary>
    void Respawn()
    {
        this.transform.position = spawnPoint;
    }

    /// <summary>
    /// Fades the camera to the death screen and stops the music.
    /// </summary>
    void Death()
    {
        // I still need to make the camera fadeOut
        SoundManager.instance.PlaySingle(gameOverSound);
        SoundManager.instance.musicSource.Stop();
    }
}
