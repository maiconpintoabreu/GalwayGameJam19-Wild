using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] Sound[] sounds;
    void Awake()
    {
        foreach (Sound sample in sounds)
        {
            sample.source = gameObject.AddComponent<AudioSource>();
            sample.source.clip = sample.clip;
            sample.source.volume = sample.volume;

            sample.source.pitch = sample.pitch;

        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }


    public void PlayOneShot(string name)
    {
        //finds the name of the sound in the array
        Sound sample = Array.Find(sounds, sound => sound.name == name);

        //Plays One shot
        sample.source.PlayOneShot(sample.source.clip);
    }
}
