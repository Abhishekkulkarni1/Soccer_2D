using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Text enemyBanner;
    public Text playerBanner;

    public Text pauseText;
    public Button continueButton;
    public Button exitButton;
    private bool isPaused = false;

    void Start()
    {
        pauseText.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        
        Button contbtn = continueButton.GetComponent<Button>();
        contbtn.onClick.AddListener(DeactivatePauseMenu);
        
        Button exitbtn = exitButton.GetComponent<Button>();
        exitbtn.onClick.AddListener(ReturnToMainMenu);
    }
    
    void Update()
    {
        int scoreEnemy = ScoreLogic.enemyScore;
        string scoreString = scoreEnemy.ToString();
        enemyBanner.text = "Enemy: " + scoreString;
        
        int scorePlayer = ScoreLogic.playerScore;
        string scoreStringPlayer = scorePlayer.ToString();
        playerBanner.text = "Player: " + scoreStringPlayer;

        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            print("Pause Game");
            ActivatePauseMenu();
            Time.timeScale = 0;
            isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            print("Resume");
            DeactivatePauseMenu();
        }
    }

    public void ActivatePauseMenu()
    {
        pauseText.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }

    public void DeactivatePauseMenu()
    {
        pauseText.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }

    public void ReturnToMainMenu()
    {
        DeactivatePauseMenu();
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }
}
