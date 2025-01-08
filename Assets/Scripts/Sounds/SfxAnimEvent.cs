using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxAnimEvent : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;

    public void PlaySFX(int index)
    {
        SoundManager.Instance.PlaySFX(audioClips[index]);
    }
}
