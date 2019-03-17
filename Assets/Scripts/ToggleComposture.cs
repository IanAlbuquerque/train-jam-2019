using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleComposture : MonoBehaviour
{
    [SerializeField]
    private KeyCode key;

    [SerializeField]
    private Rigidbody2D targetRigidBody;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(this.key)) {
            this.targetRigidBody.freezeRotation = !this.targetRigidBody.freezeRotation;
        }
    }
}
