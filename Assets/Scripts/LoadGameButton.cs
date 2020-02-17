﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadGameButton : MonoBehaviour
{
    Button btnLoadGame;
    public string key;
    
    void Awake()
    {
        btnLoadGame = GetComponent<Button>();
     
    }
    public void Update(){
        if (Input.GetKeyDown (key))
        {
                EventSystem.current.SetSelectedGameObject(this.gameObject);
                
                SceneManager.LoadScene("Level01");
                btnLoadGame.gameObject.SetActive(false);
        }
  
    }   
}