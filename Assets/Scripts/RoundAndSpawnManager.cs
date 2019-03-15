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

    public SceneFader sceneFader;

    public string winScene = "WinOrLoseScreen";
    public string mainMenuScene = "MainMenu";

    private int roundNumber;                  // Which round the game is currently on.
    private WaitForSeconds startWait;         // Used to have a delay whilst the round starts.
    private WaitForSeconds endWait;           // Used to have a delay whilst the round or game ends.
    private PlayerManager roundWinner;          // Reference to the winner of the current round.  Used to make an announcement of who won.
    private PlayerManager gameWinner;           // Reference to the winner of the game.  Used to make an announcement of who won.


    private void Start()
    {
        // Create the delays so they only have to be made once.
        startWait = new WaitForSeconds(roundStartDelay);
        endWait = new WaitForSeconds(roundEndDelay);

        SpawnPlayers();
        SetCameraTargets();

        // Once the tanks have been created and the camera is using them as targets, start the game.
        StartCoroutine(GameLoop());
    }


    private void SpawnPlayers()
    {
        // For all the tanks...
        for (int i = 0; i < playerArray.Length; i++)
        {
            // ... create them, set their player number and references needed for control.
            playerArray[i].instanceOfPlayer =
                Instantiate(playerPrefab, playerArray[i].spawnPoint.position, playerArray[i].spawnPoint.rotation) as GameObject;
            playerArray[i].playerNumber = i + 1;
            //playerArray[i].Setup();
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
        //DisablePlayerControl();

        // Snap the camera's zoom and position to something appropriate for the reset tanks.
        //camControl.SetStartPositionAndSize();

        // Increment the round number and display text showing the players what round it is.
        roundNumber++;
        messageText.text = "ROUND " + roundNumber;

        // Wait for the specified length of time until yielding control back to the game loop.
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

        // Now the winner's score has been incremented, see if someone has one the game.
        gameWinner = GetGameWinner();

        // Get a message based on the scores and whether or not there is a game winner and display it.
        string message = EndMessage();
        messageText.text = message;

        // Wait for the specified length of time until yielding control back to the game loop.
        yield return endWait;
    }


    // This is used to check if there is one or fewer tanks remaining and thus the round should end.
    private bool OnePlayerLeft()
    {
        // Start the count of tanks left at zero.
        int numTanksLeft = 0;

        // Go through all the tanks...
        for (int i = 0; i < playerArray.Length; i++)
        {
            // ... and if they are active, increment the counter.
            if (playerArray[i].instanceOfPlayer.activeSelf)
                numTanksLeft++;
        }

        // If there are one or fewer tanks remaining return true, otherwise return false.
        return numTanksLeft <= 1;
    }


    // This function is to find out if there is a winner of the round.
    // This function is called with the assumption that 1 or fewer tanks are currently active.
    private PlayerManager GetRoundWinner()
    {
        // Go through all the tanks...
        for (int i = 0; i < playerArray.Length; i++)
        {
            // ... and if one of them is active, it is the winner so return it.
            if (playerArray[i].instanceOfPlayer.activeSelf)
                return playerArray[i];
        }

        // If none of the tanks are active it is a draw so return null.
        return null;
    }


    // This function is to find out if there is a winner of the game.
    private PlayerManager GetGameWinner()
    {
        // Go through all the tanks...
        for (int i = 0; i < playerArray.Length; i++)
        {
            // ... and if one of them has enough rounds to win the game, return it.
            if (playerArray[i].numberOfWins == numRoundsToWin)
                return playerArray[i];
        }

        // If no tanks have enough rounds to win, return null.
        return null;
    }


    private string EndMessage()
    {
        string message = "DRORGI!\n(Draw + Corgi)";

        if (roundWinner != null)
            message = roundWinner.gertrudeOrJerryColor + " WINS DOG LOVE!";

        message += "\n\n\n\n";

        for (int i = 0; i < playerArray.Length; i++)
        {
            message += playerArray[i].gertrudeOrJerryColor + ": " + playerArray[i].numberOfWins + " ";
        }

        if (gameWinner != null)
            message = gameWinner.gertrudeOrJerryColor + " ADOPTS THE DOG!";

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

