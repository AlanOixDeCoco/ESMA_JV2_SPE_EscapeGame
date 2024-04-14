using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class FadeInOut : MonoBehaviour
{
    [SerializeField] private Image _fadeImage;
    [SerializeField] private Color _clearColor, _maskColor;
    
    public IEnumerator FadeIn(float duration)
    {
        _fadeImage.enabled = true;
        var startTime = Time.time;
        var endTime = startTime + duration;
        var elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime = Time.time - startTime;
            var t = elapsedTime / duration;
            _fadeImage.color = Color.Lerp(_clearColor, _maskColor, t);
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForEndOfFrame();
    }
    
    public IEnumerator FadeOut(float duration)
    {
        var startTime = Time.time;
        var endTime = startTime + duration;
        var elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            elapsedTime = Time.time - startTime;
            var t = elapsedTime / duration;
            _fadeImage.color = Color.Lerp(_maskColor, _clearColor, t);
            yield return new WaitForEndOfFrame();
        }
        _fadeImage.enabled = false;

        yield return new WaitForEndOfFrame();
    }
}
