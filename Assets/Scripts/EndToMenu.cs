using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndToMenu : MonoBehaviour
{
    public SceneFader sceneFader;

    public string menuScene = "MainMenu";
    public void Update()
    {
        if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape))
        {
            //FMODUnity.RuntimeManager.PlayOneShot(GameStartSFX);
            //MusicBox.SetActive(false);
            this.LoadMainScene();
        }
    }

    void LoadMainScene()
    {
        sceneFader.FadeTo(menuScene);
    }
}
