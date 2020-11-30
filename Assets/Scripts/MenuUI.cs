using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    void Start()
    {
        //SceneManager.LoadScene("Menu", LoadSceneMode.Additive); 

        startButton.onClick.AddListener(CallGame);
        exitButton.onClick.AddListener(ExitApplication);
    }

    void CallGame()
    {
        // TODO suggested rename: "StartGame" (think about it, then delete this comment)

        print("call game was called!");
        SceneManager.LoadScene("Game");
    }

    void ExitApplication()
    {
        Application.Quit();
    }
}