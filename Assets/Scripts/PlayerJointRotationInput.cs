using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJointRotationInput : MonoBehaviour
{
    [SerializeField]
    private KeyCode key;

    [SerializeField]
    private Rigidbody2D targetRigidBody;

    [SerializeField]
    private float maxIntensity;

    [SerializeField]
    private float direction = 1.0f;

    [SerializeField]
    private float minScale = 1.0f;

    [SerializeField]
    private float maxScale = 2.0f;

    [SerializeField]
    private GameObject visualIndicator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(this.key)) {
            this.targetRigidBody.AddTorque(this.direction * this.maxIntensity);
        }
        float currentScale = Mathf.Lerp(this.minScale, this.maxScale, Mathf.Abs(this.direction));
        this.visualIndicator.transform.localScale = new Vector3(    currentScale,
                                                                    currentScale,
                                                                    this.visualIndicator.transform.localScale.z);
    }
}
