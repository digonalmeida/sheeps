using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    //Control Variables
    public float audioFadeOutFactor = 1.5f;

    //Audio Source Reference
    public AudioSource audioSourceSFX;
    public AudioSource audioSourceMusic;

    //SFX Clips
   
    public AudioClip clipSFX_WolfKill;
    public AudioClip clipSFX_TossLanding;
    public AudioClip clipSFX_FallUncounscious;
    public AudioClip clipSFX_Meesenger;

    //SFX Clips (Random)
    public List<AudioClip> clipSFX_BleatNeutral;
    public List<AudioClip> clipSFX_BleatFear;
    public List<AudioClip> clipSFX_HowlWolves;
    public List<AudioClip> clipSFX_CaptureOther;
    public List<AudioClip> clipSFX_YellToss;
    public List<AudioClip> clipSFX_Punch;

    //Music Clips
    public AudioClip clipMusic_CalmPhase;
    public AudioClip clipMusic_ChaosPhase;
    public AudioClip clipMusic_GameOver;

    private static AudioController instance;
    public static AudioController Instance
    {
        get
        {
            return instance;
        }
    }

    //On Object Awake
    private void Awake()
    {
        //Check Singleton
        if (instance != null && instance != this) Destroy(this);
        else instance = this;
    }

    private void Start()
    {
        playMusic(clipMusic_CalmPhase);
    }

    public void playSFX(AudioClip sfxClip)
    {
        if(sfxClip != null) audioSourceSFX.PlayOneShot(sfxClip);
    }

    public void playSFX(List<AudioClip> sfxClip)
    {
        if (sfxClip != null && sfxClip.Count > 0)
        {
            AudioSource.PlayClipAtPoint(sfxClip[Random.Range(0, sfxClip.Count)], Camera.main.transform.position);
        }
    }

    public void playMusic(AudioClip musicClip)
    {
        if(audioSourceMusic.clip == null)
        {
            audioSourceMusic.clip = musicClip;
            audioSourceMusic.Play();
        }
        else StartCoroutine("changeMusic", musicClip);
    }

    public IEnumerator changeMusic(AudioClip musicClip)
    {
        while(audioSourceMusic.volume >= 0f)
        {
            audioSourceMusic.volume -= audioFadeOutFactor;
            yield return null;
        }

        //Change Music
        audioSourceMusic.Stop();
        audioSourceMusic.clip = musicClip;
        audioSourceMusic.Play();

        while (audioSourceMusic.volume <= 100f)
        {
            audioSourceMusic.volume += audioFadeOutFactor;
            yield return null;
        }
    }
}
