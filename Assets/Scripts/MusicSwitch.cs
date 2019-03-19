using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitch : MonoBehaviour
{  
    public FMOD.Studio.EventInstance BattleMusic;

    //public FMOD.Studio.ParameterInstance IsPlayingGame;
    
    // Start is called before the first frame update
    void Start()
    {
        BattleMusic = FMODUnity.RuntimeManager.CreateInstance("event:/BattleMusic");
    }

    void Update()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collider)
    {
        BattleMusic.start();
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        BattleMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
