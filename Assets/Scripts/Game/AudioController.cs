using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _ambiantSource;

    private void Start()
    {
        DontDestroyOnLoad(_musicSource.gameObject);
        DontDestroyOnLoad(_ambiantSource.gameObject);
    }

    public void PlayMusic()
    {
        _musicSource.volume = 0f;
        _musicSource.Play();
        StartCoroutine(FadeVolume(_musicSource, 1f, 1.5f));
    }
    public void PauseMusic()
    {
        StartCoroutine(PauseMusicCoroutine());
    }
    private IEnumerator PauseMusicCoroutine()
    {
        yield return StartCoroutine(FadeVolume(_musicSource, 0f, 1.5f));
        _musicSource.Pause();
    }
    
    public void PlayAmbiant()
    {
        _ambiantSource.volume = 0f;
        _ambiantSource.Play();
        StartCoroutine(FadeVolume(_ambiantSource, 1f, 1.5f));
    }
    public void PauseAmbiant()
    {
        StartCoroutine(PauseAmbiantCoroutine());
    }
    private IEnumerator PauseAmbiantCoroutine()
    {
        yield return StartCoroutine(FadeVolume(_ambiantSource, 0f, 1.5f));
        _ambiantSource.Pause();
    }

    private IEnumerator FadeVolume(AudioSource source, float targetVolume, float fadeDuration)
    {
        var startVolume = source.volume;
        var startTime = Time.time;
        var endTime = startTime + fadeDuration;
        var elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime = Time.time - startTime;
            var t = elapsedTime / fadeDuration;
            source.volume = Mathf.Lerp(startVolume, targetVolume, t);
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForEndOfFrame();
    }
}
