using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; // make list that contain all sounds
    // Start is called before the first frame update
    void Start()
    {
        foreach(Sound s in sounds)  // to get each sound in list Sound
        {
            s.source = gameObject.AddComponent<AudioSource>(); 
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
        PlaySound("MainTheme"); // to play sound MainTheme all the game 
    }

    public void PlaySound(string name) // method to play the sound that it take its name
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
                s.source.Play();
        }
    }
}
