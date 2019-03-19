using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactsGertrude : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string impactSoundEffect;

    [FMODUnity.EventRef]
    public string GertrudeEffort;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Jerry")
        {
            FMODUnity.RuntimeManager.PlayOneShot(impactSoundEffect);
            FMODUnity.RuntimeManager.PlayOneShot(GertrudeEffort);
        }
    }
}
