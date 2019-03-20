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
    public Text messageText;
    public GameObject player1Prefab; 
    public GameObject player2Prefab;

    public PlayerManager player1Manager;
    public PlayerManager player2Manager;

    public TimingManagerScript timingManagerScript;

    public SceneFader sceneFader;

    public string winSceneGertrude = "WinOrLoseScreen";
    public string winSceneJerry = "WinOrLoseScreenJerry";
    public string mainMenuScene = "MainMenu";

    private int roundNumber;                  
    private WaitForSeconds startWait;         
    private WaitForSeconds endWait;
    private PlayerManager roundWinner;  
    private PlayerManager gameWinner; 

    public Text player1ScoreText;
    public Text player2ScoreText;

    public bool canControlCharacters = false; 

    public Animator roundStartAnimator;
    
    public Text roundText;

    [FMODUnity.EventRef]
    public string RoundCountDown;

    public ParticleSystem endGamePawticle;

    public ParticleSystem endRoundPawticle;


    private void Start()
    {
        this.canControlCharacters = false;
        SpawnPlayers();
        this.roundNumber = 1;
        this.roundText.text = "Round " + this.roundNumber.ToString();
        this.messageText.text = "Prepare for Battle!";
        this.roundStartAnimator.SetTrigger("run");
        FMODUnity.RuntimeManager.PlayOneShot(RoundCountDown);
    }

    private void Update() {
        this.player1ScoreText.text = this.player1Manager.numberOfWins.ToString();
        this.player2ScoreText.text = this.player2Manager.numberOfWins.ToString();
    }

    private void SpawnPlayers()
    {
        this.player1Manager.instanceOfPlayer = Instantiate(this.player1Prefab, this.player1Manager.spawnPoint.position, this.player1Manager.spawnPoint.rotation) as GameObject;
        this.player1Manager.instanceOfPlayer.GetComponent<PlayerSetter>().init(this.timingManagerScript, this);
        this.player2Manager.instanceOfPlayer = Instantiate(this.player2Prefab, this.player2Manager.spawnPoint.position, this.player2Manager.spawnPoint.rotation) as GameObject;
        this.player2Manager.instanceOfPlayer.GetComponent<PlayerSetter>().init(this.timingManagerScript, this);
    }

    private void DespawnPlayers() {
        GameObject.Destroy(this.player1Manager.instanceOfPlayer);
        GameObject.Destroy(this.player2Manager.instanceOfPlayer);
    }


    private void triggerPlayerOverallVictory(int playerNumber)
    {
        //Instantiate(endGamePawticle, player1Manager.transform.position - player2Manager.transform.position, player1Manager.transform.rotation);
        endGamePawticle.Play();
        this.sceneFader.FadeTo(playerNumber==1?this.winSceneGertrude:this.winSceneJerry);
    }

    public void triggerRoundStart() {
        this.canControlCharacters = true;
    }

    public void triggerPlayerRoundVictory(int playerNumber)
    {
        //Instantiate(endRoundPawticle, player1Manager.transform.position - player2Manager.transform.position, player1Manager.transform.rotation);
        endRoundPawticle.Play();
        this.roundNumber++;
        this.roundText.text = "Round " + this.roundNumber.ToString();
        this.canControlCharacters = false;
        if (playerNumber == 1) {
            this.player1Manager.numberOfWins += 1;
        } else {
            this.player2Manager.numberOfWins += 1;
        }
        if(this.player1Manager.numberOfWins >= this.numRoundsToWin) {
            this.triggerPlayerOverallVictory(1);
        } else if(this.player2Manager.numberOfWins >= this.numRoundsToWin) {
            this.triggerPlayerOverallVictory(2);
        }
        if (this.player1Manager.numberOfWins <= 2  && this.player2Manager.numberOfWins <= 2)
        {
            FMODUnity.RuntimeManager.PlayOneShot(RoundCountDown);
        }
        else { return; }

        this.DespawnPlayers();
        this.SpawnPlayers();
        this.messageText.text = (playerNumber==1?"Gertrude":"Jerry") + " won the round!";
        this.roundStartAnimator.SetTrigger("run");
    }
}

