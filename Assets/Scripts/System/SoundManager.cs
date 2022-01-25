using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public static SoundManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    // 
    public AudioClip[] oneShotClips;
    public AudioClip[] BGMClips;
    public AudioSource audioSource;
    public AudioSource audioSourcePitch;
    
    public void playOneShot(int i)
    {
        audioSource.PlayOneShot(oneShotClips[i]);
    }
    public void playOnePitchShot(int i, float pitch)
    {
        audioSourcePitch.pitch = pitch;
        audioSourcePitch.PlayOneShot(oneShotClips[i]);
    }
    public void playBGM(int i)
    {
        audioSource.clip = BGMClips[i];
        
        audioSource.Play();
    }
}
