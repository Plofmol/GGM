using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [Header("--------- Audio Source -----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------- Audio Clip -----------")]
    public AudioClip Start_music;
    public AudioClip Ominous_music;
    public AudioClip Explore_music;
    public AudioClip Escape_music;

    public AudioClip Door;
    public AudioClip Elevator;

    public AudioClip small_gun;
    public AudioClip reloadsmall;
    public AudioClip shotgun;
    public AudioClip reloadshot;
    public AudioClip bazooka;
    public AudioClip reloadbazooka;

    public AudioClip Jump;
    public AudioClip Hit;
    public AudioClip run;
    public AudioClip fall;

    public AudioClip die;

}
