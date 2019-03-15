using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutofBounds : MonoBehaviour
{
    [SerializeField]
    private Text collisionDetectText;

    [SerializeField]
    private string displayText;

    [SerializeField]
    GameObject rightCollider;

    [SerializeField]
    GameObject leftCollider;

    [SerializeField]
    Rigidbody2D playerRigidbody;


    void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.tag)
        collisionDetectText.text = "" + displayText + " collider hit!";
    }
}
