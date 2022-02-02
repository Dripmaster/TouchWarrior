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
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        isBGMJ = false;
        volume = 1;
    }
    public static SoundManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType(typeof(SoundManager)) as SoundManager;
                DontDestroyOnLoad(instance.gameObject);
                return instance;
            }
            return instance;
        }
    }
    // 
    public AudioClip[] oneShotClips;
    public AudioClip[] BGMClips;
    public AudioSource audioSource;
    public AudioSource audioSourceBGM;
    public AudioSource audioSourcePitch;
    float volume;
    public void playOneShot(int i,float v = 1)
    {
        audioSource.volume = v;
        audioSource.PlayOneShot(oneShotClips[i]);
    }
    public void playOnePitchShot(int i, float pitch)
    {
        audioSourcePitch.pitch = pitch;
        audioSourcePitch.PlayOneShot(oneShotClips[i]);
    }
    bool isBGMJ;
    public void playBGM(int i)
    {
        if (isBGMJ && i == 0) return;
        if(i == 0)
            isBGMJ = true;
        if (i == 1)
            isBGMJ = false;
        audioSourceBGM.clip = BGMClips[i];

        audioSourceBGM.Play();
    }
    public void endBgm()
    {
        isBGMJ = false;
        audioSourceBGM.Stop();
    }
}
