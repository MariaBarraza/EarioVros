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
        if(other.tag=="Player")
        {
           if(gameManager.diamondPieces == 1)
            {
                diamond.Visible();
                Destroy(gameObject);
            }else
            {
                gameManager.diamondPieces++;
                Debug.Log(gameManager.diamondPieces); 
                Destroy(gameObject);
            }
        }
    }
}
