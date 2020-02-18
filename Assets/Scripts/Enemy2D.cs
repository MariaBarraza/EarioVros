using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2D : MonoBehaviour
{
     [SerializeField]
    float delay;
    float timer;
    [SerializeField]
    float speed;

    [SerializeField]
    Vector2 dir;

    protected void KillPlayer(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if (player!= null)
            {
                player.Hit();
            }
        }
    }

    protected void HorizontalMovement()
    {
         {
        transform.Translate(dir * speed * Time.deltaTime);
        timer +=  Time.deltaTime;
        if(timer >= delay)
        {
            timer = 0f;
            dir.x = dir.x > 0 ? -1 : 1;
           // IFlip flip = new NPCFlip();
           // spr.flipX = flip.FlipSprite(dir.x, spr);
        }
    }
    }
    protected void VerticalMovement()
    {
        transform.Translate(dir * speed * Time.deltaTime);
        timer +=  Time.deltaTime;
        if(timer >= delay)
        {
            timer = 0f;
            dir.y = dir.y > 0 ? -1 : 1;
           // IFlip flip = new NPCFlip();
           // spr.flipX = flip.FlipSprite(dir.x, spr);
        }
    }
}
