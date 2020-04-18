using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelect : MonoBehaviour
{

    public Transform[] Characters;
    public Transform activeCharacter;
    public GameObject selectscreen;


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
        selectscreen.SetActive(false);
        Time.timeScale = 1;
    }

    void DisablePlayerScripts()
    {
        foreach (var c in Characters)
        {
            var scripts = c.GetComponents<MonoBehaviour>();
            print(scripts.Length + "found in " + c.name);
            foreach (var s in scripts)
            {
                print(s.name + " disabled");
                s.enabled = false;
            }
            c.tag = "Untagged";
        }

    }
}
