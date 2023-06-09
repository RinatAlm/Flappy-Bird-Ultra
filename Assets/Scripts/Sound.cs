using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public AudioClip clip;
    public bool isMusic;
    public string name;

    [Range(0,1)]
    public float origVolume = 1;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

}