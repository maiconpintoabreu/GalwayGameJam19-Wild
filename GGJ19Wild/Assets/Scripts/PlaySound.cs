using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    //Wwise(Matt)
    public AK.Wwise.Event PlaySounds;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void PlaySFX()
    {
        PlaySounds.Post(gameObject);
    }

   
}
