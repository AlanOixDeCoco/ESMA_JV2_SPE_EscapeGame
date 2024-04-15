using UnityEngine;

public class TimeController : MonoBehaviour
{
    private bool _isPaused = true;
    private bool _isActive = true;
    
    private float _time;

    private void Start()
    {
        ResetTime();
    }

    private void FixedUpdate()
    {
        if(!_isActive) return;
        
        if(!_isPaused) _time += Time.fixedDeltaTime;
        if (GetRemainingTime() <= 0)
        {
            _isActive = false;
            GameController.Instance.ActiveSceneController.OnLevelFail();
            GameController.Instance.StartCoroutine(GameController.Instance.Gameover(false));
        }
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
        _isActive = true;
        _isPaused = true;
        _time = 0f;
    }

    public float GetRemainingTime()
    {
        var gameDuration = GameController.Instance.GameDuration * 60;
        var remainingTime = gameDuration - _time;
        if(remainingTime < 0) remainingTime = 0;
        return remainingTime;
    }
}
