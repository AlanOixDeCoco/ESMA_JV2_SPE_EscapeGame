using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _duration;
    [SerializeField] private bool _loop;
    [SerializeField] private bool _playOnEnable = false;
    [SerializeField] private UnityEvent _onTimerStart, _onTimerPause, _onTimerResume, _onTimerEnd, _onTimerCancel;

    private bool _started = false;
    private bool _paused = false;
    private float _startTime;
    private float _remainingTime;

    private void OnEnable()
    {
        if (_playOnEnable) StartTimer();
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        _started = false;
        _paused = false;
    }

    public void StartTimer()
    {
        _remainingTime = _duration;
        StartCoroutine(ProcessTimer(_remainingTime));

        _onTimerStart.Invoke();
        
        _started = true;
        _paused = false;
    }

    public void PauseTimer()
    {
        if (_started)
        {
            StopAllCoroutines();
            var elapsedTime = Time.time - _startTime;
            _remainingTime = _duration - elapsedTime;

            _paused = true;

            _onTimerPause.Invoke();
        }
        else Debug.Log("The timer hasn't started yet");
    }

    public void ResumeTimer()
    {
        if (_paused)
        {
            StartCoroutine(ProcessTimer(_remainingTime));
            _paused = false;
            _onTimerResume.Invoke();
        }
        else Debug.Log("The timer hasn't paused yet");
    }

    public void CancelTimer()
    {
        if (_started)
        {
            StopAllCoroutines();
            _started = false;
            _onTimerCancel.Invoke();
        }
        else Debug.Log("The timer hasn't started yet");
    }

    private IEnumerator ProcessTimer(float duration)
    {
        _startTime = Time.time;
        
        yield return new WaitForSeconds(_duration);
        
        _onTimerEnd.Invoke();

        yield return new WaitForEndOfFrame();
    }
}
