﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMover : MonoBehaviour
{
    [SerializeField]
    private Button startButton;

    [SerializeField]
    private Button creditsButton;

    [SerializeField]
    private Button quitButton;

    [SerializeField]
    private Button nextOnInstructionsButton;

    [SerializeField]
    private Button returnToMainMenuButton;

    [SerializeField]
    public Animator pauseAnim;

    public string dogFightMainGame = "BrawlScene";

    public string creditsScene = "Credits";

    public string mainMenuScene = "MainMenu";

    public string winLoseScene = "WinLoseScreen";

    public SceneFader sceneFader;


    void Start()
    {
        pauseAnim.SetBool("isPause", false);
    }

    public void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            pauseAnim.SetBool("isPaused", true);
        }
    }

    public void LoadMainScene()
    {
        sceneFader.FadeTo(dogFightMainGame);
    }

    public void LoadCredits()
    {
        sceneFader.FadeTo(creditsScene);
    }

    public void ReturnToMainMenu()
    {
        sceneFader.FadeTo(mainMenuScene);
    }

    public void GoToWinLoseScreen()
    {
        sceneFader.FadeTo(winLoseScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}


