using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Sprite[] tuts;
    [SerializeField] GameObject tutorial, mainMenu, btnNext, btnLoad;
    private void OnEnable()
    {
        if (tutorial != null)
        {
            tutorial.SetActive(false);
        }
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

    public void LoadTutorial()
    {
        tutorial.SetActive(true);
        mainMenu.SetActive(false);
        tutorial.GetComponentInChildren<Image>().sprite = tuts[0];
    }


    public void NextPage()
    {
        tutorial.GetComponentInChildren<Image>().sprite = tuts[1];
        btnNext.SetActive(false);
        btnLoad.SetActive(true);
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
