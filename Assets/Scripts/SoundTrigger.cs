using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SoundTrigger : MonoBehaviour
{
    //AudioSource source;
    //Collider2D soundTrigger;
    AudioManager audioManager;

    private void Awake()
    {
        //source = GetComponent<AudioSource>();
        //soundTrigger = GetComponent<Collider2D>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("music");
        audioManager.PlayMusic(audioManager.Ominous_music);
        //source.Play();
    }
}
