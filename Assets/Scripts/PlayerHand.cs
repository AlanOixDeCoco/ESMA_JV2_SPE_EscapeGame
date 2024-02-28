using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerHand : PlayerComponent
{
    [Header("Rotation")]
    [SerializeField] private float _rotationSpeed = 90f;
    [SerializeField] private float _rotationOffset = -90f;

    [Header("Pick")]
    [SerializeField] private float _pickDuration = .5f;
    
    [Header("Drop")]
    [SerializeField] private float _dropVelocity = 2f;

    [Header("Rendering")] 
    [SerializeField] private String _selectedLayer;
    
    // Rendering
    private LayerMask _baseLayer;
    
    // Pickable
    private bool _picking = false;
    private bool _holdPickable = false;
    private Pickable _pickable;
    private Transform _pickableTransform;
    private Transform _pickableInitialParent;

    // Rotation values
    private float _handRotation = 0;
    private float _pickableRotation = 0;

    public bool HoldPickable => _holdPickable; // Property --> .HasPickable

    public bool TryGetPickable(out Pickable pickable)
    {
        if (_holdPickable)
        {
            pickable = _pickable;
            return true;
        }
        pickable = null;
        return false;
    }

    private void Start()
    {
        InputManager.Instance.PlayerInputs.FPS_Gameplay.Drop.started += DropObject;
    }

    private void Update()
    {
        if(HoldPickable && !_picking) ProcessRotation(InputManager.Instance.PlayerInputs.FPS_Gameplay.Inspect.ReadValue<Vector2>());
    }

    public bool TryPickObject(Transform pickableTransform)
    {
        if (HoldPickable || _picking) return false;

        StartCoroutine(PickObject(pickableTransform));
        return true;
    }

    private IEnumerator PickObject(Transform pickableTransform)
    {
        _picking = true;

        var pickableGameobject = pickableTransform.gameObject;
        
        // Store base layer
        _baseLayer = pickableGameobject.layer;
        
        // Change pickable layer to apply custom renderer
        pickableGameobject.layer = LayerMask.NameToLayer(_selectedLayer);
        
        _handRotation = _rotationOffset;
        _pickableRotation = 0f;
        
        // Rotate hand
        _playerManager.PlayerHand.localEulerAngles = Vector3.right * _handRotation;
        
        _pickableTransform = pickableTransform;
        _pickableInitialParent = _pickableTransform.parent;
        _pickableTransform.SetParent(_playerManager.PlayerHand);

        var initialPos = _pickableTransform.localPosition;
        var initialRotation = _pickableTransform.localRotation;
        float time = 0;
        while (time < _pickDuration)
        {
            time += Time.deltaTime;
            _pickableTransform.localPosition = Vector3.Lerp(initialPos, Vector3.zero, time/_pickDuration);
            _pickableTransform.localRotation = Quaternion.Lerp(initialRotation, Quaternion.identity, time/_pickDuration);
            yield return new WaitForEndOfFrame();
        }
        _pickableTransform.localPosition = Vector3.zero;
        
        _holdPickable = true;

        _picking = false;

        yield return new WaitForEndOfFrame();
    }

    public void DropObject(InputAction.CallbackContext context)
    {
        if (_pickableTransform != null)
        {
            _holdPickable = false;
            
            _pickableTransform.parent = _pickableInitialParent;
            
            var pickableRb = _pickableTransform.GetComponent<Rigidbody>();
            pickableRb.isKinematic = false;
            pickableRb.velocity = 
                GetComponent<CharacterController>().velocity * _dropVelocity;
            
            // Reset layer
            _pickableTransform.gameObject.layer = _baseLayer;
        
            _pickableTransform = null;
        }
    }
    
    private void ProcessRotation(Vector2 input)
    {
        _playerManager.PlayerHand.localEulerAngles = Vector3.right * _handRotation;
        _pickableTransform.localEulerAngles = Vector3.forward * _pickableRotation;

        _handRotation += input.y * _rotationSpeed * Time.deltaTime;
        _pickableRotation += -input.x * _rotationSpeed * Time.deltaTime;

        _handRotation = Mathf.Clamp(_handRotation, -160f + _rotationOffset, 160 + _rotationOffset);
        _pickableRotation = Mathf.Clamp(_pickableRotation, -160f, 160);
    }
}
