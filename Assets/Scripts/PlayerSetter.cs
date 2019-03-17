using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetter : MonoBehaviour
{
    public List<PlayerJointRotationInput> scripts;

    public void init(TimingManagerScript timingManagerScript) {
        foreach(PlayerJointRotationInput script in this.scripts) {
            script.init(timingManagerScript);
        }
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
