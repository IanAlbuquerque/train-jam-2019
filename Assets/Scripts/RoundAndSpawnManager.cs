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
    // public CameraController camControl;
    public Text messageText;
    public GameObject player1Prefab; 
    public GameObject player2Prefab;

    public PlayerManager player1Manager;
    public PlayerManager player2Manager;

    public TimingManagerScript timingManagerScript;

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

    public Text player1ScoreText;
    public Text player2ScoreText; 


    private void Start()
    {
        // Create the delays
        this.startWait = new WaitForSeconds(this.roundStartDelay);
        this.endWait = new WaitForSeconds(this.roundEndDelay);

        SpawnPlayers();
        // SetCameraTargets();

        StartCoroutine(GameLoop());
    }

    private void Update() {
        this.player1ScoreText.text = this.player1Manager.numberOfWins.ToString();
        this.player2ScoreText.text = this.player2Manager.numberOfWins.ToString();
    }

    private void SpawnPlayers()
    {
        this.player1Manager.instanceOfPlayer = Instantiate(this.player1Prefab, this.player1Manager.spawnPoint.position, this.player1Manager.spawnPoint.rotation) as GameObject;
        this.player1Manager.instanceOfPlayer.GetComponent<PlayerSetter>().init(this.timingManagerScript);
        this.player2Manager.instanceOfPlayer = Instantiate(this.player2Prefab, this.player2Manager.spawnPoint.position, this.player2Manager.spawnPoint.rotation) as GameObject;
        this.player2Manager.instanceOfPlayer.GetComponent<PlayerSetter>().init(this.timingManagerScript);
    }

    private void DespawnPlayers() {
        GameObject.Destroy(this.player1Manager.instanceOfPlayer);
        GameObject.Destroy(this.player2Manager.instanceOfPlayer);
    }


    // private void SetCameraTargets()
    // {
    //     Transform[] targets = new Transform[playerArray.Length];

    //     for (int i = 0; i < targets.Length; i++)
    //     {
    //         targets[i] = playerArray[i].instanceOfPlayer.transform;
    //     }

    // }

    private IEnumerator GameLoop()
    {
        // yield return StartCoroutine(RoundStarting());

        // yield return StartCoroutine(RoundPlaying());

        // yield return StartCoroutine(RoundEnding());
        
        // if (gameWinner != null)
        // {
        //     // If there is a game winner, restart level
        //     this.sceneFader.FadeTo(this.winScene);
        // }
        // else
        // {
        //     StartCoroutine(GameLoop());
        // }

        yield return null;
    }


    // private IEnumerator RoundStarting()
    // {
    //     //round start player reset
    //     ResetPlayers();
    //     roundNumber++;
    //     messageText.text = "ROUND " + roundNumber;

    //     yield return startWait;
    // }


    // private IEnumerator RoundPlaying()
    // {
    //     // Clear the text 
    //     messageText.text = string.Empty;
   
    //     while (!OnePlayerLeft())
    //     {
    //         yield return null;
    //     }
    // }


    // private IEnumerator RoundEnding()
    // {
    //     // Clear the winner from previous round
    //     roundWinner = null;

    //     roundWinner = GetRoundWinner();

    //     if (roundWinner != null)
    //         roundWinner.numberOfWins++;

    //     gameWinner = GetGameWinner();

    //     string message = EndMessage();
    //     messageText.text = message;
    //     yield return endWait;
    // }

    // private PlayerManager GetRoundWinner()
    // {
    //     for (int i = 0; i < playerArray.Length; i++)
    //     {
    //         if (playerArray[i].instanceOfPlayer.activeSelf)
    //             return playerArray[i];
    //     }
    //     return null;
    // }

    // private PlayerManager GetGameWinner()
    // {
    //     for (int i = 0; i < playerArray.Length; i++)
    //     {
    //         if (playerArray[i].numberOfWins == numRoundsToWin)
    //             return playerArray[i];
    //     }
    //     return null;
    // }


    // private string EndMessage()
    // {
    //     string message = "DRORGI!\n(Draw + Corgi)";

    //     if (roundWinner != null)
    //     {
    //         message = roundWinner.gertrudeOrJerryColor + " IS THE PAWRENT";
    //         Instantiate(roundHasEndedParticles, playerPrefab.transform);
    //     }

    //     message += "\n\n\n\n";

    //     for (int i = 0; i < playerArray.Length; i++)
    //     {
    //         message += playerArray[i].gertrudeOrJerryColor + ": " + playerArray[i].numberOfWins + " ";
    //     }

    //     if (gameWinner != null)
    //     {
    //         message = gameWinner.gertrudeOrJerryColor + " ADOPTS THE DOG!";
    //         Instantiate(gameHasEndedParticles, messageText.transform);
    //     }

    //     return message;
    // }

    private void triggerPlayerOverallVictory(int playerNumber) {
        this.sceneFader.FadeTo(this.winScene);
    }

    public void triggerPlayerRoundVictory(int playerNumber) {
        Debug.Log(playerNumber.ToString() + " won round!");
        if(playerNumber == 1) {
            this.player1Manager.numberOfWins += 1;
        } else {
            this.player2Manager.numberOfWins += 1;
        }
        this.DespawnPlayers();
        this.SpawnPlayers();
        if(this.player1Manager.numberOfWins >= this.numRoundsToWin) {
            this.triggerPlayerOverallVictory(1);
        } else if(this.player2Manager.numberOfWins >= this.numRoundsToWin) {
            this.triggerPlayerOverallVictory(2);
        }
    }
}

