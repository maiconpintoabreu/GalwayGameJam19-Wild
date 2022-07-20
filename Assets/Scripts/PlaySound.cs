using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    //Wwise(Matt)
    //public AK.Wwise.Event PlaySounds;
   // public AK.Wwise.Event PlayFlyingSounds;
    //public AK.Wwise.Event PlaySwimmingSounds;
    //public AK.Wwise.Event PlayDiggingSounds;
   // public AK.Wwise.Event PlayRustlingSounds;
    // Music
    //public AK.Wwise.Event Music;
    //
    // Start is called before the first frame update
    void Start()
    {
        //Music Start
        //Music.Post(gameObject);
        FindObjectOfType<AudioManager>().PlayOneShot("Music");

    }

    public void PlayTransformSFX()
    {
        //PlaySounds.Post(gameObject);
        FindObjectOfType<AudioManager>().PlayOneShot("TransformSFX");
    }

    public void PlayCardSFX()
    {
        //PlaySounds.Post(gameObject);
        FindObjectOfType<AudioManager>().PlayOneShot("CardSFX");
    }

    public void PlayFlyingSFX()
    {
        FindObjectOfType<AudioManager>().PlayOneShot("FlyingSFX");
    }

    public void PlaySwimmingSFX()
    {
        FindObjectOfType<AudioManager>().PlayOneShot("SwimmingSFX");
    }

    public void PlayDiggingSFX()
    {
        FindObjectOfType<AudioManager>().PlayOneShot("DiggingSFX");
    }

    public void PlayRustlingSFX()
    {
        FindObjectOfType<AudioManager>().PlayOneShot("RustlingSFX");
    }


    //Music Stop
    public void StopMusicPlaying()
    {
        //Music.Stop(gameObject);
    }

}
