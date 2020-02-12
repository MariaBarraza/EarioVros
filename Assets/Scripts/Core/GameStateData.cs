using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameStateData
{
    public float[] position;
    public bool completedFirstLevel;
    public bool completedSecondLevel;
    public bool completedThirdLevel;
    public string scenename2;
    public string scenename;
    Scene scene;

    public GameStateData(GameState gameState) 
    {
        position = new float[3];
        position[0] = gameState.transform.position.x;
        position[1] = gameState.transform.position.y;

        scene = SceneManager.GetActiveScene();
        scenename = SceneManager.GetActiveScene().name;

        completedFirstLevel = gameState.completedFirstLevel;
        completedSecondLevel = gameState.completedSecondLevel;
        completedThirdLevel = gameState.completedThirdLevel;
    }
}