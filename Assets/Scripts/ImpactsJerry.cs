using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactsJerry : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string impactSoundEffect;

    [FMODUnity.EventRef]
    public string JerryEffort;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gertrude")
        {
            FMODUnity.RuntimeManager.PlayOneShot(impactSoundEffect);
            FMODUnity.RuntimeManager.PlayOneShot(JerryEffort);
        }
    }
}
