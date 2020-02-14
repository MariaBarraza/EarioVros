using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField]
    float delay;
    float timer;
    [SerializeField]
    float speed;

    [SerializeField]
    Vector2 dir;

    int lifes;
     void Update()
    {
        Movement();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit");
         Player player = other.GetComponent<Player>();

            if (player!= null)
            {
                player.Hit();
            }
    }

    private void Movement()
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
