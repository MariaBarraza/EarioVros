using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] string scene;
    Animator anim;

    void Awake(){
        anim = GetComponent<Animator>();
    }
    
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene(scene);
    }

    void YouWin()
    {
        anim.SetTrigger("isTouched");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            YouWin();
            StartCoroutine(ChangeScene());
        }
    }
}