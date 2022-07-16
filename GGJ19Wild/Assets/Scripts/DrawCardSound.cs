using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCardSound : MonoBehaviour
{
    //Wwise(Matt)
    public AK.Wwise.Event DrawCardSounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void DrawCardSFX()
    {
        DrawCardSounds.Post(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
