using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJointRotationInput : MonoBehaviour
{
    public KeyCode key;

    public Rigidbody2D targetRigidBody;

    public float maxIntensity;

    float direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(this.key)) {
            Debug.Log("Pressed!");
            this.targetRigidBody.AddTorque(this.maxIntensity);
        }
    }
}
