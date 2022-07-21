using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    [HideInInspector]
    public AudioSource source;

    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1; //default value in inspector
    [Range(0f, 3f)]
    public float pitch = 1; //default value in inspector



}
