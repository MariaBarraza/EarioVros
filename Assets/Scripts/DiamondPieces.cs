using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondPieces : MonoBehaviour
{
    private Diamond diamond;
    private GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        diamond = FindObjectOfType<Diamond>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            gameManager.diamondPieces++;
            Destroy(gameObject);

            if (gameManager.diamondPieces == 2)
            {
                diamond.Visible();
            }
        }
    }
}
