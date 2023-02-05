using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource introSoundtrack;

    [SerializeField]
    private AudioSource LoopSoundTrack;

    [SerializeField]
    private AudioSource CrashSound;

    public static SoundManager Instance;

    private UnityAction _onCrashCone;

    Coroutine SongPlaying;


    private void Awake()
    {
        Instance = this;
        SongPlaying = StartCoroutine(RestartSound());
    }

    public void PlayCrashSound(UnityAction onCrashDone)
    {
        this._onCrashCone = onCrashDone;
        StopSound();
        if (SongPlaying  != null)
        {
            StopSound();
        }

        SongPlaying = StartCoroutine(PlayCrash());
    }


    private IEnumerator PlayCrash()
    {
        CrashSound.Play();
        while (CrashSound.isPlaying)
        {
            yield return null;
        }

        _onCrashCone?.Invoke();
        yield return RestartSound();
    }

    private IEnumerator PlaySong()
    {
        introSoundtrack.Play();
        while (introSoundtrack.isPlaying)
        {
            yield return null;
        }
        LoopSoundTrack.Play();
    }

    public IEnumerator RestartSound()
    {
        StopSound();
        yield return PlaySong();
    }

    public void StopSound()
    {
        if (SongPlaying != null) 
        { 
        StopCoroutine(SongPlaying);
        }
        
        SongPlaying = null;
        introSoundtrack.Stop();
        LoopSoundTrack.Stop();
    }


}
