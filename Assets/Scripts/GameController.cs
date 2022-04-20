using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text healthText;

    //variavel para armazenar as moedas 
    public int score;
    public Text scoreText;

    //pause 
    public GameObject pauseObj;
    private bool isPaused;

    public int arrows;
    public Text arrowsText;
    
    //game over 
    public GameObject gameroverObj;
    //win game
    public GameObject winObj;

    public int totalScore;
    
    // para acessar esse script de outro script 
    public static GameController instance;
    
    //Awake e inicializado antes de todos os metodos start() do seu projeto 
    void Awake()
    {
        instance = this;
        
        Debug.Log(PlayerPrefs.GetInt("score"));
        
        Time.timeScale = 1f;
    }

    void Start()
    {
        totalScore = PlayerPrefs.GetInt("score"); 
        
        UpdateArrows(0);
    }
    void Update()
    {
        PauseGame();
    }

    public void UpdateScore(int value)
    {
        score += value;
        scoreText.text = "x " + score.ToString();
        //Codigo para o save
        PlayerPrefs.SetInt("score", score + totalScore);
    }

    public void UpdateLives(int value)

    {
        healthText.text = "x " + value.ToString(); 
    }

    public void UpdateArrows(int value)
    {
        arrows += value;
        arrowsText.text = "x " + arrows.ToString();
    }

    //metodo do pause
    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            pauseObj.SetActive(isPaused);
            
            //time.timescale para chamar o pause 
            if (isPaused)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }
    
    //metodo para o game over 
    public void GameOver()
    {
        gameroverObj.SetActive(true);
        Time.timeScale = 0f;
    }

    public void WinGame()
    {
        winObj.SetActive(true);
        Time.timeScale = 0f;
    }

    //metodo para voltar para o menu
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    
    //metodo para reiniciar o jogo quando morrer 
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }


}
