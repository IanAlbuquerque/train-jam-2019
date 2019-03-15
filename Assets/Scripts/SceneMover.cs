using System.Collections;
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

    

    public void LoadMainScene()
    {
        SceneManager.LoadScene("BrawlScene");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}


