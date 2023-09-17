using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class btnFX : MonoBehaviour
{
    public AudioSource menuFx;
    public AudioClip hoverFx;
    public AudioClip clickFx;

    //play sound on mouse hover
    public void HoverSound()
    {
        menuFx.PlayOneShot(hoverFx);
    }

    //play sound on mouse click
    public void ClickSound()
    {
        menuFx.PlayOneShot(clickFx);
    }
}
