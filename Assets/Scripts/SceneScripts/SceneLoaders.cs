using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class SceneLoaders : MonoBehaviour {

    public Scene myScene;
    public Button startButton;
    public Button quitButton;

    void Awake()
    {
    }

    void Start()
    {
        // startButton = startButton.GetComponent<Button>();
       // startButton.name = "Play Game";
        //quitButton = quitButton.GetComponent<Button>();
    }


    void Update()
    {
      
    }

    public void StartLevel()
    {
        DisableButton();
        SceneManager.LoadScene(1);
    }

    public void OnRestart()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnQuit()
    {
        Application.Quit();
    }

    void DisableButton ()
    {
        startButton.enabled = false;
        quitButton.enabled = false;
    }
}