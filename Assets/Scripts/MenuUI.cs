using System.Collections;
using System.Collections.Generic;
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
        
        Button strttbtn = startButton.GetComponent<Button>();
        strttbtn.onClick.AddListener(CallGame);
        
        Button exitbtn = exitButton.GetComponent<Button>();
        exitbtn.onClick.AddListener(ExitApplication);
        
    }

    
    void Update()
    {
        
    }

    void CallGame()
    {
        print("call game was called!");
        SceneManager.LoadScene("Game");
    }

    void ExitApplication()
    {
        Application.Quit();
    }
}
