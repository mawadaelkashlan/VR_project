using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name; // declare the name of sound 
    public AudioClip clip; // to upload sound from pc
    public float volume; // to limit the volume of sound
    public bool loop; // to make the sound available all the game 
    public AudioSource source; //to define the source of sound
}
