using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : SingletonDestroy<AudioController>
{
    //Control Variables
    public float audioFadeOutFactor = 0.15f;

    //Audio Source Reference
    public AudioSource audioSourceSFX;
    public AudioSource audioSourceMusic;

    //SFX Clips
    public AudioClip clipSFX_Rooster;
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

    private void Start()
    {
        //playMusic(clipMusic_CalmPhase);
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
        else {
            StopAllCoroutines();
            StartCoroutine(changeMusic(musicClip));
        }
    }

    public IEnumerator changeMusic(AudioClip musicClip)
    {
        while(audioSourceMusic.volume > 0f)
        {
            audioSourceMusic.volume -= audioFadeOutFactor * Time.deltaTime;
            yield return 0;
        }

        //Change Music
        audioSourceMusic.Stop();
        audioSourceMusic.clip = musicClip;
        audioSourceMusic.Play();

        while (audioSourceMusic.volume < 1f)
        {
            audioSourceMusic.volume += audioFadeOutFactor * Time.deltaTime;
            yield return 0;
        }
    }

    public void stopMusicWithFadeOut()
    {
        StopAllCoroutines();
        StartCoroutine(fadeOutMusic());
    }

    public IEnumerator fadeOutMusic()
    {
        while (audioSourceMusic.volume > 0f)
        {
            audioSourceMusic.volume -= audioFadeOutFactor * Time.deltaTime;
            yield return 0;
        }

        audioSourceMusic.Stop();
    }
}
