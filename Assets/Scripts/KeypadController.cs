using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class KeypadController : MonoBehaviour
{
    [SerializeField] private string _rightSequence = "0000";

    [SerializeField] private UnityEvent _onRightSequence, _onWrongSequence;

    [SerializeField] private TextMeshProUGUI _sequenceDisplay;
    
    private string _currentSequence;

    private void Start()
    {
        ResetSequence();
    }

    private void ResetSequence()
    {
        _currentSequence = "";
        if (_sequenceDisplay != null) _sequenceDisplay.text = _currentSequence;
    }

    public void AddToSequence(string fragment)
    {
        _currentSequence += fragment;
        
        if (_sequenceDisplay != null) _sequenceDisplay.text = _currentSequence;
        
        if (_currentSequence.Length >= _rightSequence.Length)
        {
            CheckSequence();
        }
    }

    private bool CheckSequence()
    {
        // Check if right sequence
        if (_currentSequence.Equals(_rightSequence))
        {
            _onRightSequence.Invoke();
            return true;
        }
        
        _onWrongSequence.Invoke();
        ResetSequence();
        return false;
    }
}