using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectPlayer : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1,sfx2,sfx3;

    //sfx1 normal
    //sfx2 ominous
    //sfx3 Blasting
    //sfx4 Escape


    // Start is called before the first frame update
    void Start()
    {
        src.clip = sfx1;
        src.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnterDungeon()
    {
        src.clip = sfx2;
        src.Play();
    }

    void LeaveDungeon()
    {
        src.clip = sfx3;
        src.Play();
    }

}
