using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingManagerScript : MonoBehaviour
{
    [SerializeField]
    private float time;

    [SerializeField]
    private float tickSignal;

    [SerializeField]
    private GameObject tick;

    [SerializeField]
    private GameObject leftTick;


    [SerializeField]
    private GameObject rightTick;


    [SerializeField]
    private GameObject centerTick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.tickSignal < 0) {
            this.tick.transform.position = Vector3.Lerp( this.leftTick.transform.position,
                                                            this.centerTick.transform.position,
                                                            this.getTimeAbs());
        } else {
            this.tick.transform.position = Vector3.Lerp( this.rightTick.transform.position,
                                                            this.centerTick.transform.position,
                                                            this.getTimeAbs());
        }
    }

    public float getTime() {
        return this.time;
    }

    public float getTimeAbs() {
        return Mathf.Abs(this.time);
    }
}
