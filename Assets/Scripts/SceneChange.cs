using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
   [SerializeField] string scene;
  public void ChangeScene()
  {
        SceneManager.LoadScene(scene); 
  }
  
   void OnTriggerEnter2D(Collider2D other)
    {
        ChangeScene();
    }
}