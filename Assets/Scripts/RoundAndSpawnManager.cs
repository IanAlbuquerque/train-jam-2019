using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoundAndSpawnManager : MonoBehaviour
{
    public int numRoundsToWin = 3;            
    public float roundStartDelay = 3f;
    public float roundEndDelay = 3f;
    public CameraController camControl;
    public Text messageText;
    public GameObject playerPrefab; 
    public PlayerManager[] playerArray;

    [SerializeField]
    public GameObject roundHasEndedParticles;

    [SerializeField]
    public GameObject gameHasEndedParticles;

    [SerializeField]
    public Animator pauseAnim;
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;


    public SceneFader sceneFader;

    public string winScene = "WinOrLoseScreen";
    public string mainMenuScene = "MainMenu";

    private int roundNumber;                  
    private WaitForSeconds startWait;         
    private WaitForSeconds endWait;
    private PlayerManager roundWinner;  
    private PlayerManager gameWinner;  


    private void Start()
    {
        pauseAnim.SetBool("isPaused", false);

        // Create the delays
        startWait = new WaitForSeconds(roundStartDelay);
        endWait = new WaitForSeconds(roundEndDelay);

        SpawnPlayers();
        SetCameraTargets();

        StartCoroutine(GameLoop());
    }

    //void Update()
    //{
        
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        //Set the pause menu UI active
    //        if (gameIsPaused)
    //        {
    //            Resume();
    //        }
    //        else
    //        {
    //            Pause();
    //        }
    //    }

    //}
    //public void Resume()
    //{
    //    pauseAnim.SetBool("isPaused", false);
    //    Time.timeScale = 1f;
    //    gameIsPaused = false;
    //}

    //public void Pause()
    //{
    //    pauseAnim.SetBool("isPaused", true);
    //    gameIsPaused = true;
    //}

    //public void LoadMenu()
    //{
    //    Time.timeScale = 1f;
    //    SceneManager.LoadScene("Title");
    //}


    private void SpawnPlayers()
    {
        for (int i = 0; i < playerArray.Length; i++)
        {
            playerArray[i].instanceOfPlayer =
                Instantiate(playerPrefab, playerArray[i].spawnPoint.position, playerArray[i].spawnPoint.rotation) as GameObject;
            playerArray[i].playerNumber = i + 1;
        }
    }


    private void SetCameraTargets()
    {
        Transform[] targets = new Transform[playerArray.Length];

        for (int i = 0; i < targets.Length; i++)
        {
            targets[i] = playerArray[i].instanceOfPlayer.transform;
        }

    }

    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundStarting());

        yield return StartCoroutine(RoundPlaying());

        yield return StartCoroutine(RoundEnding());
        
        if (gameWinner != null)
        {
            // If there is a game winner, restart level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            StartCoroutine(GameLoop());
        }
    }


    private IEnumerator RoundStarting()
    {
        //round start player reset
        ResetPlayers();
        roundNumber++;
        messageText.text = "ROUND " + roundNumber;

        yield return startWait;
    }


    private IEnumerator RoundPlaying()
    {
        // Clear the text 
        messageText.text = string.Empty;
   
        while (!OnePlayerLeft())
        {
            yield return null;
        }
    }


    private IEnumerator RoundEnding()
    {
        // Clear the winner from previous round
        roundWinner = null;

        roundWinner = GetRoundWinner();

        if (roundWinner != null)
            roundWinner.numberOfWins++;

        gameWinner = GetGameWinner();

        string message = EndMessage();
        messageText.text = message;
        yield return endWait;
    }

    private bool OnePlayerLeft()
    {
        int numTanksLeft = 0;

        for (int i = 0; i < playerArray.Length; i++)
        {
            if (playerArray[i].instanceOfPlayer.activeSelf)
                numTanksLeft++;
        }
        return numTanksLeft <= 1;
    }

    private PlayerManager GetRoundWinner()
    {
        for (int i = 0; i < playerArray.Length; i++)
        {
            if (playerArray[i].instanceOfPlayer.activeSelf)
                return playerArray[i];
        }
        return null;
    }

    private PlayerManager GetGameWinner()
    {
        for (int i = 0; i < playerArray.Length; i++)
        {
            if (playerArray[i].numberOfWins == numRoundsToWin)
                return playerArray[i];
        }
        return null;
    }


    private string EndMessage()
    {
        string message = "DRORGI!\n(Draw + Corgi)";

        if (roundWinner != null)
        {
            message = roundWinner.gertrudeOrJerryColor + " IS THE PAWRENT";
            Instantiate(roundHasEndedParticles, playerPrefab.transform);
        }

        message += "\n\n\n\n";

        for (int i = 0; i < playerArray.Length; i++)
        {
            message += playerArray[i].gertrudeOrJerryColor + ": " + playerArray[i].numberOfWins + " ";
        }

        if (gameWinner != null)
        {
            message = gameWinner.gertrudeOrJerryColor + " ADOPTS THE DOG!";
            Instantiate(gameHasEndedParticles, messageText.transform);
        }

        return message;
    }

    // Reset at their spawn points
    private void ResetPlayers()
    {
        for (int i = 0; i < playerArray.Length; i++)
        {
            playerArray[i].Reset();
        }
    }
}

