using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    public Transform spawnPoint;

    [SerializeField]
    public Color gertrudeOrJerryColor;

    public int numberOfWins;

    public GameObject instanceOfPlayer;

    public int playerNumber;

    public void Reset()
    {
        instanceOfPlayer.transform.position = spawnPoint.transform.position;

        instanceOfPlayer.SetActive(false);
        instanceOfPlayer.SetActive(true);
    }
}
