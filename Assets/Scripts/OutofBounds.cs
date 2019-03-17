using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutofBounds : MonoBehaviour
{
    public string tagString;

    public int victoriousPlayerNumber;

    public RoundAndSpawnManager roundAndSpawnManager;


    void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.tag)
        if(collision.gameObject.CompareTag(this.tagString)) {
            this.roundAndSpawnManager.triggerPlayerRoundVictory(this.victoriousPlayerNumber);
        }
    }
}
