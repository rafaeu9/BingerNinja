﻿//Joao Beijinho

//Joao Beijinho 05/11/2020 - Created the script, triggers to check if player can interact, and calling interaction in update
//Joao Beijinho 09/11/2020 - Replaced tags with the tags in the Tags_JoaoBeijinho script
//Joao Beijinho 27/11/2020 - Made an array for ControlPanelActivateObject to allow the control panel to activate multiple objects

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

/// <summary>
/// This class acts as a button which calls interactions from the object that it is referencing
/// </summary>
public class ControlPanel_JoaoBeijinho : MonoBehaviour
{
    protected PlayerController_JamieG m_playerControllerScript;
    public ControlPanelActivateObject_JoaoBeijinho[] m_activateObjectScript;
    private LevelScripting levelScripting;

    private string m_playerTag = "Player";

    public bool m_canPressButton = false;
    private void Start()
    {
        levelScripting = GameObject.Find("Player").GetComponent<LevelScripting>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags_JoaoBeijinho.m_playerTag))
        {
           
            m_canPressButton = true;
            print("Can Press");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags_JoaoBeijinho.m_playerTag))
        {
         
            m_canPressButton = false;
            print("Cannot Press");
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        m_playerControllerScript = FindObjectOfType<PlayerController_JamieG>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_playerControllerScript.m_interact.triggered && m_canPressButton == true)//Player interaction with button
        {
            if (SceneManager.GetActiveScene().buildIndex == 6)
            {
                if (levelScripting.drawFreezer)
                {
                    levelScripting.drawFreezer = false;
                }
                else
                {
                    levelScripting.drawFreezer = true;
                }
                
            }
            for (int i = 0; i < m_activateObjectScript.Length; i++)
            {
                m_activateObjectScript[i].ActivateObject();
                print("SMOKE");
            }
        }
    }
}
