using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{

    public Transform[] Characters;
    public Transform activeCharacter;
    public GameObject selectscreen;


    private void OnEnable()
    {
        GameTriggers.OnWaveEnd += DisplaySelectScreen;
    }

    private void OnDisable()
    {
        GameTriggers.OnWaveEnd -= DisplaySelectScreen;
    }
    //DEBUG
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            DisplaySelectScreen();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        selectscreen.SetActive(false);
        DisablePlayerScripts();
        DisplaySelectScreen();
    }

    private void DisplaySelectScreen()
    {
        GameTriggers.OnCharSelect();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        selectscreen.SetActive(true);
        DisablePlayerScripts();
        Time.timeScale = 0;

     

    }

    
    public void SelectPlayer(Transform character)
    {
        var scripts = character.GetComponents<MonoBehaviour>();

        foreach (var s in scripts)
        {
            s.enabled = true;
        }

        activeCharacter = character;
        character.tag = "Player";
        GameTriggers.OnPlayerAssigned();
        selectscreen.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    void DisablePlayerScripts()
    {
        foreach (var c in Characters)
        {
            var scripts = c.GetComponents<MonoBehaviour>();
            foreach (var s in scripts)
            {
                s.enabled = false;
            }
            c.tag = "Untagged";
        }

    }
}
