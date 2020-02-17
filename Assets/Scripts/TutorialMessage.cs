using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMessage : MonoBehaviour
{
   [SerializeField]
    SpriteRenderer sprite;

   [SerializeField]
    SpriteRenderer sprite2;

    // Start is called before the first frame update
    void Start()
    {
       sprite.enabled = false;
       sprite2.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
       sprite.enabled = true;  
    }

    private void Update() {
       if(sprite.enabled == true) 
       {
          sprite2.enabled = true;
       }
    }

}