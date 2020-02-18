using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : Enemy2D
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        KillPlayer(other);
    }
}
