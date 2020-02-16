using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Enemy2D
{
    // Start is called before the first frame update
    void Update()
    {
        HorizontalMovement();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       KillPlayer(other);
    }
}
