using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour
{
    public AudioSource music;
    void Start()
    {
        music.enabled = true;
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
