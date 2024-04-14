using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControllerBridge : MonoBehaviour
{
    public void Pause()
    {
        GameController.Instance.TimeController.Pause();
    }

    public void Resume()
    {
        GameController.Instance.TimeController.Resume();
    }
}
