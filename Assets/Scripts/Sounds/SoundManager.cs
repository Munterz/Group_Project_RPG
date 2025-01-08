using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource sourceBGM, sourceSfx;    
    

    public static SoundManager Instance;


    private void Awake ()
    {
        Instance = this;
    }

    public void PlayBGM (AudioClip clip)
    {
        sourceBGM.clip = clip;
        sourceBGM.loop = true;
        sourceBGM.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        sourceSfx.PlayOneShot(clip);
    }
}
