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
    private float minIntensity;

    [SerializeField]
    private float maxIntensity;

    [SerializeField]
    private TimingManagerScript timingManageScript;

    [SerializeField]
    private bool invertAxis = false;

    [SerializeField]
    private bool timeAbs = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float time = this.timeAbs?this.timingManageScript.getTimeAbs():this.timingManageScript.getTime();
        if(Input.GetKeyDown(this.key)) {
            this.targetRigidBody.AddTorque(Mathf.Lerp(this.minIntensity, this.maxIntensity, Mathf.Abs(time)) * Mathf.Sign(time) * (this.invertAxis?-1.0f:1.0f));
        }
    }
}
