using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    
    public static AudioManager instance;
    public Sound[] sounds;
    public bool isMainMusicRunning;
    public float volume;
    


    [System.Serializable]
    class Volume    //     -------- Data for Json       
    {
        public float volume;        
    }

    public void SaveVolume() //Transfering data into Json Format
    {
        Volume data = new Volume();
        data.volume = volume;     
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveVolume.json", json); //To use files   
       // Debug.Log("Saved" + volume.ToString());
    }
    public void LoadVolume() //Transfering data from Json Format
    {

        string path = Application.persistentDataPath + "/saveVolume.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Volume data = JsonUtility.FromJson<Volume>(json);
            volume = data.volume;           
        }
        else
        {
            volume = 1;
        }
       // Debug.Log("Loaded" + volume.ToString());
        
    }
    private void Awake()
    {
       
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        
              
    }

    private void Start()
    {
        SetVolume();
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
        if(s.isMusic)
        {
            isMainMusicRunning = true;
        }
      
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Stop();
        if (s.isMusic)
        {
            isMainMusicRunning = false;
        }

    }
    public void SetAudio()
    {
       
        foreach (Sound s in sounds)
        {
            s.source.volume = volume;
        }
    }


    public void SetVolume()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = volume * s.origVolume;
            s.source.loop = s.loop;
        }
    }
}