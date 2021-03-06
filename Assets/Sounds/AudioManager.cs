using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{   
    private float LowPitchRange = 0.95f;
    private float HighitchRange = 1.5f;
    public Sound [] sounds;

    public static AudioManager instance;

    void Awake() {
        if (instance == null){
            instance = this;
        
        }
        else{
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
         Play("ambience");
    }

    public void Play(string name){
       Sound s = Array.Find(sounds, sound => sound.name == name);
        
       if (s==null){
           Debug.LogWarning("Sound: " + name + " not found!");
           //return;
       }
        s.source.Play();
    }
    public void PlaySFX (string sound)
    {
    Sound s = Array.Find(sounds, item => item.name == sound);
     if (s == null)
    {
        Debug.LogWarning("Sound: " + name + " not found!");
         return;
    }

        s.source.volume = s.volume;
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(LowPitchRange, HighitchRange));

        s.source.Play ();
    }
    public void Stop(string name){
       Sound s = Array.Find(sounds, sound => sound.name == name);
        
       if (s==null){
           Debug.LogWarning("Sound: " + name + " not found!");
           //return;
       }
        s.source.Stop();
    }
    

   
}
