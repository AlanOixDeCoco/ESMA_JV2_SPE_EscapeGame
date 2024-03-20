using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private bool _isPaused = false;
    
    private float _time;

    private void Start()
    {
        _time = 0f;
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
}
