using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRoundStart : MonoBehaviour
{
    public RoundAndSpawnManager roundAndSpawnManager;

    public void triggerRoundStart() {
        this.roundAndSpawnManager.triggerRoundStart();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
