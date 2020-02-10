using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public float speed = 10f;
    public bool completedFirstLevel = false;
    public bool completedSecondLevel = false;
    public bool completedThirdLevel = false;
    public string scenename;
    public Scene scene;
    
    public void SaveGameState()
    {
        SaveSystem.SaveGameState(this);
    }

    public void LoadGameState()
    {
        GameStateData data = SaveSystem.LoadGameState();

        SceneManager.LoadScene(data.scenename);
        
        completedFirstLevel = data.completedFirstLevel;
        completedSecondLevel = data.completedSecondLevel;
        completedThirdLevel = data.completedThirdLevel;
    }
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Guardado Exitoso");
            SaveGameState();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Carga Exitosa");
            LoadGameState();
        }
    }
}