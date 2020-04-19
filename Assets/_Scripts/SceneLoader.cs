using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    private void OnEnable()
    {
        GameTriggers.OnGameStart += LoadGame;
        GameTriggers.OnGameEnd += LoadGameOver;
        GameTriggers.OnGameRestart += onRestartBtn;
        GameTriggers.OnGameQuit += OnQuitButtonClick;
    }

    private void OnDisable()
    {
        GameTriggers.OnGameStart -= LoadGame;
        GameTriggers.OnGameEnd -= LoadGameOver;
        GameTriggers.OnGameRestart -= onRestartBtn;
        GameTriggers.OnGameQuit -= OnQuitButtonClick;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    void LoadGameOver()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(2);
    }

    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
    public void onRestartBtn()
    {
        LoadGame();
    }
    
}
