using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private GameManager gameManager;

    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            gameManager.lastCheckPointPos = this.transform.position;
            anim.SetTrigger("isTouched");
        }
    }
}
