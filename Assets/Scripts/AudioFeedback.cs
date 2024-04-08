using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFeedback : MonoBehaviour
{
    [SerializeField] private AudioClip[] _audioClips;

    public void PlayRandomFeedbackClip()
    {
        var random = Random.Range(0, _audioClips.Length);
        AudioSource.PlayClipAtPoint(_audioClips[random], transform.position);
    }
}
