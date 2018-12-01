using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : Singleton<AudioController>
{
    //Control Variables
    public float audioFadeOutFactor = 1.5f;

    //Audio Source Reference
    public AudioSource audioSourceSFX;
    public AudioSource audioSourceMusic;

    //SFX Clips
    public AudioClip clipSFX_YellToss;
    public AudioClip clipSFX_WolfKill;
    public AudioClip clipSFX_TossLanding;
    public AudioClip clipSFX_FallUncounscious;
    public AudioClip clipSFX_CaptureOther;
    public AudioClip clipSFX_DeathSheep;

    //SFX Clips (Random)
    public List<AudioClip> clipSFX_TakeDamage;
    public List<AudioClip> clipSFX_BleatNeutral;
    public List<AudioClip> clipSFX_SheepAttack;
    public List<AudioClip> clipSFX_BleatFear;
    public List<AudioClip> clipSFX_HowlWolves;

    //Music Clips
    public AudioClip clipMusic_CalmPhase;
    public AudioClip clipMusic_TensePhase;
    public AudioClip clipMusic_ChaosPhase;
    public AudioClip clipMusic_GameOver;

    private void Start()
    {
        audioSourceSFX = Camera.main.GetComponent<AudioSource>();
        audioSourceMusic = Camera.main.transform.GetChild(0).GetComponent<AudioSource>();
    }

    public void playSFX(AudioClip sfxClip)
    {
        audioSourceSFX.PlayOneShot(sfxClip);
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
