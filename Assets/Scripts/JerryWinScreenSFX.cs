using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryWinScreenSFX : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string JerryWinVox;

    [FMODUnity.EventRef]
    public string Clapping;

    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot(JerryWinVox);
        FMODUnity.RuntimeManager.PlayOneShot(Clapping);
    }
}
