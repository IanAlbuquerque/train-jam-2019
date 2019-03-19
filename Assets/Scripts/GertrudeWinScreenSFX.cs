using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GertrudeWinScreenSFX : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string GertrudeWinVox;

    [FMODUnity.EventRef]
    public string Clapping;

    // Start is called before the first frame update
    void Start()
    {
        FMODUnity.RuntimeManager.PlayOneShot(GertrudeWinVox);
        FMODUnity.RuntimeManager.PlayOneShot(Clapping);
    }

}
