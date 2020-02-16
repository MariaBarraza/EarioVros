using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Enemy2D
{
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        
       sprite = gameObject.GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
       KillPlayer(other);
       sprite.enabled= true;
    }

}
