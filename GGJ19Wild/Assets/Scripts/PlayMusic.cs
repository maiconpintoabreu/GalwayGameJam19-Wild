using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Music Start
        //Music.Post(gameObject);

        FindObjectOfType<AudioManager>().PlayOneShot("Music");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
