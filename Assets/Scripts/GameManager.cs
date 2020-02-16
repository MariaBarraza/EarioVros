﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;


    GameObject player;

    
    public GameObject Player {get => player; set => player = value; }

    Vector2 playerPos;

    public Vector2 PlayerPos{ get => playerPos; set => playerPos = value;}

    public Vector2 lastCheckPointPos;
    public Vector2 initialPosition;

    GameStateData gameData;

    public GameStateData GameData{ get => gameData; set => gameData = value; }

    public bool dead=false;
    public int diamondPieces;

    void Awake()
    {
        initialPosition = new Vector2(PlayerPos.x,PlayerPos.y);
        lastCheckPointPos = new Vector2(PlayerPos.x,PlayerPos.y);
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }
        /// <summary>
    /// Returns the player to its starting position.
    /// </summary>
    void Respawn()
    {
        if(dead)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                dead=false;
            }
        }
    }

    public void Start()
    {
        /*GameStateData data = SaveSystem.LoadGameState();
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        player.transform.position = position;
        */
    }
    public void Update()
    {
        Respawn();
    }
}
