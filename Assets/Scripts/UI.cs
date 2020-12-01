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
    private bool _isPaused = false;

    void Start()
    {
        // TODO suggestion: make a list of buttons and apply actions over lists. ask me

        pauseText.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);

        continueButton.onClick.AddListener(DeactivatePauseMenu);
        exitButton.onClick.AddListener(ReturnToMainMenu);
    }

    void Update()
    {
        enemyBanner.text = "Enemy: " + ScoreLogic.EnemyScore;
        playerBanner.text = "Player: " + ScoreLogic.PlayerScore;

        if (Input.GetKeyDown(KeyCode.Escape) && !_isPaused)
        {
            print("Pause Game");
            ActivatePauseMenu();
            Time.timeScale = 0;
            _isPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _isPaused)
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
        _isPaused = true;
    }

    public void DeactivatePauseMenu()
    {
        pauseText.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
        Time.timeScale = 1;
        _isPaused = false;
    }

    public void ReturnToMainMenu()
    {
        DeactivatePauseMenu();
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);
    }
}