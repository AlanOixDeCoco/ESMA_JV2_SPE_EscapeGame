using UnityEngine;

public class TimeController : MonoBehaviour
{
    private bool _isPaused = true;
    
    private float _time;

    private void Start()
    {
        ResetTime();
    }

    private void FixedUpdate()
    {
        if(!_isPaused) _time += Time.fixedDeltaTime;
    }

    public void Pause()
    {
        _isPaused = true;
    }

    public void Resume()
    {
        _isPaused = false;
    }

    public void ResetTime()
    {
        _isPaused = true;
        _time = 0f;
    }

    public float GetRemainingTime()
    {
        var gameDuration = GameController.Instance.GameDuration * 60;
        return gameDuration - _time;
    }
}
