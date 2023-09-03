using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnFX : MonoBehaviour
{
    public AudioSource menuFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;

    public void HoverSound()
    {
        menuFx.PlayOneShot(hoverFx);
    }

    public void ClickSound()
    {
        menuFx.PlayOneShot(clickFx);
    }
}
