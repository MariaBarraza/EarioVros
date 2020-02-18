using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Enemy2D
{
  
     void Update()
    {
        VerticalMovement();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       KillPlayer(other);
    }
}
