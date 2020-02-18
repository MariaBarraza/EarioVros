using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    bool firstCollision = true;

    [SerializeField]
    Vector2 position;

    public bool canSeeDiamond = false;

    private GameManager gameManager;

    SpriteRenderer sprite;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        sprite = GetComponent<SpriteRenderer>();
        
        // Hide Sprite
        sprite.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (canSeeDiamond)
            {
                if (firstCollision)
                {
                    transform.position = new Vector2(position.x, position.y);
                    firstCollision = false;
                }
                else
                {
                    Destroy(gameObject);
                    
                    gameManager.win = true;
                    gameManager.Win();
                }
            }
        }
    }

    public void Visible()
    {
        canSeeDiamond = true;
        sprite.enabled= true;
    }
}
