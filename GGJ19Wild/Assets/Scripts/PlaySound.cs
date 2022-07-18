using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    //Wwise(Matt)
    public AK.Wwise.Event PlaySounds;
    public AK.Wwise.Event PlayFlyingSounds;
    public AK.Wwise.Event PlaySwimmingSounds;
    public AK.Wwise.Event PlayDiggingSounds;
    public AK.Wwise.Event PlayRustlingSounds;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void PlaySFX()
    {
        PlaySounds.Post(gameObject);
    }

    public void PlayFlyingSFX()
    {
        PlayFlyingSounds.Post(gameObject);
    }

    public void PlaySwimmingSFX()
    {
        PlaySwimmingSounds.Post(gameObject);
    }

    public void PlayDiggingSFX()
    {
        PlayDiggingSounds.Post(gameObject);
    }

    public void PlayRustlingSFX()
    {
        PlayRustlingSounds.Post(gameObject);
    }




}
