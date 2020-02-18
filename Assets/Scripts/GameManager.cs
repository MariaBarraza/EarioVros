using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    GameObject player;

    
    public GameObject Player {get => player; set => player = value; }

    Vector2 playerPos;

    public Vector2 PlayerPos{ get => playerPos; set => playerPos = value;}

    public Vector2 lastCheckPointPos;
    public Vector2 initialPosition;

    GameStateData gameData;

    public GameStateData GameData{ get => gameData; set => gameData = value; }

    public bool dead=false;

    public bool win=false;
    public int diamondPieces;

    
    int hearts = 0;
    [SerializeField]
    public int lives = 3;
    [SerializeField]
    Text txtLives;

    [SerializeField]
    Sprite emptyHeart;
    [SerializeField]
    Sprite heart; 
    [SerializeField]
    Image[] imageHearts = new Image[3];

     [SerializeField]
    Image blkImage;
    [SerializeField]
    Image gameOverImage;
    [SerializeField]
    Text txtGameOver;
     [SerializeField]
    Image winImage;


    void Awake()
    {
        initialPosition = new Vector2(PlayerPos.x,PlayerPos.y);
        lastCheckPointPos = new Vector2(PlayerPos.x,PlayerPos.y);
        UpdateLives(0);        
    }

    void Respawn()
    {
        if(dead)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                UpdateLives(3);
                dead=false;
               
            }
        }else if(win)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("menu");
                win = false;
            }
        }
    }

        public void AddHeart()
    {
        hearts += 1;
        switch(hearts)
        {
            case 1:
                imageHearts[0].sprite = heart;
                imageHearts[1].sprite = emptyHeart;
                imageHearts[2].sprite = emptyHeart;
                break;
            case 2:
                imageHearts[0].sprite = heart;
                imageHearts[1].sprite = heart;
                imageHearts[2].sprite = emptyHeart;
                break;
            case 3:
                imageHearts[0].sprite = heart;
                imageHearts[1].sprite = heart;
                imageHearts[2].sprite = heart;
                UpdateLives(1);
                break;
        }
    }

    public void UpdateLives(int live)
    {
        lives += live;
        txtLives.text = $"x {lives}";
    }

    public void Update()
    {
        Respawn();
    }

    public void GameOver()
    {
        StartCoroutine(FadeIn(blkImage));
        StartCoroutine(FadeIn(gameOverImage));
        StartCoroutine(FadeIn(txtGameOver));
    }

       public void Win()
    {
        StartCoroutine(FadeIn(blkImage));
        StartCoroutine(FadeIn(winImage));
    }

  IEnumerator FadeIn(MaskableGraphic element)
    {
        for(double i=0;i<=1;i+=0.1)
        {
             Color tmp = element.color;
               tmp.a = (float)i;
                      element.color = tmp;
            yield return new WaitForSeconds(0.05f);
        }
    }
    void ResetOpacity(MaskableGraphic element){
        Color tmp = element.color;
        tmp.a = 0;
         element.color = tmp;
    }

}
