using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class AudioFeedback : MonoBehaviour
{
    [Header("Audio clips")]
    [SerializeField] private AudioClip[] _audioClips;

    [Header("Feedback settings")]
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private float _collisionStrenghtThreshold = 1f;
    [SerializeField] private float _collisionMaxStrenght = 10f;
    [SerializeField] private float _maxVolume = 1f;

    public void PlayRandomFeedbackClip(float volume = 1f)
    {
        var random = Random.Range(0, _audioClips.Length);
        PlayClipAtPoint(_audioClips[random], transform.position, volume, _audioMixerGroup);
    }

    public void PlayCollisionFeedback(Collision collision)
    {
        var collisionStrenght = Mathf.Clamp(collision.relativeVelocity.magnitude, 0, _collisionMaxStrenght);
        
        if (collisionStrenght > _collisionStrenghtThreshold)
        {
            var volume = (collisionStrenght / _collisionMaxStrenght) * _maxVolume;
            PlayRandomFeedbackClip(volume);
        }
    }
    
    public static void PlayClipAtPoint(AudioClip clip, Vector3 position, float volume = 1.0f, AudioMixerGroup group = null)
    {
        if (clip == null) return;
        GameObject gameObject = new GameObject("One shot audio");
        gameObject.transform.position = position;
        AudioSource audioSource = (AudioSource) gameObject.AddComponent(typeof (AudioSource));
        if(group != null)
            audioSource.outputAudioMixerGroup = group;
        audioSource.clip = clip;
        audioSource.spatialBlend = 1f;
        audioSource.volume = volume;
        audioSource.Play();
        Destroy(gameObject, clip.length * (Time.timeScale < 0.009999999776482582 ? 0.01f : Time.timeScale));
    }
}
