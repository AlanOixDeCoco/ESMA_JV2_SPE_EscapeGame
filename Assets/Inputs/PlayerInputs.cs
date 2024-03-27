//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Inputs/PlayerInputs.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""FPS_Gameplay"",
            ""id"": ""c20060e1-1f93-4d54-8401-19611bd94e14"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""5da61e9d-b889-4b93-b2bf-d9cd48687cdb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""1f4ffde7-09c4-4da4-8df5-3b1f2735ab03"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Value"",
                    ""id"": ""0b0a7b62-6e61-4033-b867-fd48f4dcb279"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Inspect"",
                    ""type"": ""Value"",
                    ""id"": ""d051f827-d616-4f1a-9a99-f2f812bcd551"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""1eb2708a-4b66-409c-8e98-632c575845c3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crouch"",
                    ""type"": ""Button"",
                    ""id"": ""f358a272-298f-4ef9-b8a9-fb83bd5ca6aa"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Crawl"",
                    ""type"": ""Button"",
                    ""id"": ""ecf1c877-c5c5-4aef-933c-2994af08f05a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=0.2)"",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""81330acf-068c-449b-9259-007ef4085d6c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""5d376d41-9f8e-4fbf-8a1d-aaa752bdeeca"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b8992cf5-4f3d-4f92-af73-5276022e7ca5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9a42a94f-2571-48cb-aff8-7247cc62fd52"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b6ca3b13-bd5f-48c1-a7de-9b2438e1e4b1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7b3561f9-7c70-45da-b746-7b2de9146d22"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bfdd6873-40a9-4ffa-894f-186666ce1209"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea71170b-f4ee-4650-b5b3-5005679d95e7"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a783f67-c2f7-49a8-87d7-a334006f573a"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7b50a103-dafe-4ec0-a967-88de8c466d0b"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ebf72449-6e6a-47dd-ad12-f6e943f120ef"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""764a0c80-46b9-4e0f-b4d8-374d519c0da5"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": ""ScaleVector2(x=0.1,y=0.1)"",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a881d48f-39fd-4f41-a879-58688a3b3371"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""46dd2be9-8cf6-4e39-8bed-2192d95b8f71"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inspect"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e95000d2-7659-44c2-b080-201cdf26fec3"",
                    ""path"": ""<Mouse>/scroll/up"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=0.1)"",
                    ""groups"": """",
                    ""action"": ""Inspect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6fcadbf3-641c-4229-8b57-765e2c16ea0c"",
                    ""path"": ""<Mouse>/scroll/down"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=0.1)"",
                    ""groups"": """",
                    ""action"": ""Inspect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4fbc9229-8d2f-478d-9fce-4532f8d8d276"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inspect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1b9021ac-6e2a-4f7d-b5d1-29dfc72c5e06"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inspect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ecdafb0c-3f86-434b-ac61-5649f474ba68"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inspect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dfadc1cc-f443-4474-8090-f2ee0e332a70"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff16d653-2c6f-4e48-a833-d7371fb46e69"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c6001065-536b-46a3-b06f-7979e77c16b7"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f0632bd-3005-4b1d-8103-c3242697044e"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb0263d0-21d2-4f47-a01f-896c9dd96de7"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crouch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a7f62dbf-c575-481c-90fc-fc7ea0f9fb5f"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""762f5c72-45f0-46c7-9abf-52aafc85efb8"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crawl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbc059a6-1ad0-452e-b6fd-682600f6772b"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Crawl"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""FPS_UI"",
            ""id"": ""9a3e4510-6cf3-4cf3-87b1-2a3df6da248c"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""bfc422c3-77a4-42d5-9d4d-762d3dd53069"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2e91cad5-0e11-4b93-9734-ee60bbc4af71"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // FPS_Gameplay
        m_FPS_Gameplay = asset.FindActionMap("FPS_Gameplay", throwIfNotFound: true);
        m_FPS_Gameplay_Movement = m_FPS_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_FPS_Gameplay_Interact = m_FPS_Gameplay.FindAction("Interact", throwIfNotFound: true);
        m_FPS_Gameplay_Look = m_FPS_Gameplay.FindAction("Look", throwIfNotFound: true);
        m_FPS_Gameplay_Inspect = m_FPS_Gameplay.FindAction("Inspect", throwIfNotFound: true);
        m_FPS_Gameplay_Drop = m_FPS_Gameplay.FindAction("Drop", throwIfNotFound: true);
        m_FPS_Gameplay_Crouch = m_FPS_Gameplay.FindAction("Crouch", throwIfNotFound: true);
        m_FPS_Gameplay_Crawl = m_FPS_Gameplay.FindAction("Crawl", throwIfNotFound: true);
        m_FPS_Gameplay_Throw = m_FPS_Gameplay.FindAction("Throw", throwIfNotFound: true);
        // FPS_UI
        m_FPS_UI = asset.FindActionMap("FPS_UI", throwIfNotFound: true);
        m_FPS_UI_Pause = m_FPS_UI.FindAction("Pause", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // FPS_Gameplay
    private readonly InputActionMap m_FPS_Gameplay;
    private List<IFPS_GameplayActions> m_FPS_GameplayActionsCallbackInterfaces = new List<IFPS_GameplayActions>();
    private readonly InputAction m_FPS_Gameplay_Movement;
    private readonly InputAction m_FPS_Gameplay_Interact;
    private readonly InputAction m_FPS_Gameplay_Look;
    private readonly InputAction m_FPS_Gameplay_Inspect;
    private readonly InputAction m_FPS_Gameplay_Drop;
    private readonly InputAction m_FPS_Gameplay_Crouch;
    private readonly InputAction m_FPS_Gameplay_Crawl;
    private readonly InputAction m_FPS_Gameplay_Throw;
    public struct FPS_GameplayActions
    {
        private @PlayerInputs m_Wrapper;
        public FPS_GameplayActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_FPS_Gameplay_Movement;
        public InputAction @Interact => m_Wrapper.m_FPS_Gameplay_Interact;
        public InputAction @Look => m_Wrapper.m_FPS_Gameplay_Look;
        public InputAction @Inspect => m_Wrapper.m_FPS_Gameplay_Inspect;
        public InputAction @Drop => m_Wrapper.m_FPS_Gameplay_Drop;
        public InputAction @Crouch => m_Wrapper.m_FPS_Gameplay_Crouch;
        public InputAction @Crawl => m_Wrapper.m_FPS_Gameplay_Crawl;
        public InputAction @Throw => m_Wrapper.m_FPS_Gameplay_Throw;
        public InputActionMap Get() { return m_Wrapper.m_FPS_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FPS_GameplayActions set) { return set.Get(); }
        public void AddCallbacks(IFPS_GameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_FPS_GameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_FPS_GameplayActionsCallbackInterfaces.Add(instance);
            @Movement.started += instance.OnMovement;
            @Movement.performed += instance.OnMovement;
            @Movement.canceled += instance.OnMovement;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @Look.started += instance.OnLook;
            @Look.performed += instance.OnLook;
            @Look.canceled += instance.OnLook;
            @Inspect.started += instance.OnInspect;
            @Inspect.performed += instance.OnInspect;
            @Inspect.canceled += instance.OnInspect;
            @Drop.started += instance.OnDrop;
            @Drop.performed += instance.OnDrop;
            @Drop.canceled += instance.OnDrop;
            @Crouch.started += instance.OnCrouch;
            @Crouch.performed += instance.OnCrouch;
            @Crouch.canceled += instance.OnCrouch;
            @Crawl.started += instance.OnCrawl;
            @Crawl.performed += instance.OnCrawl;
            @Crawl.canceled += instance.OnCrawl;
            @Throw.started += instance.OnThrow;
            @Throw.performed += instance.OnThrow;
            @Throw.canceled += instance.OnThrow;
        }

        private void UnregisterCallbacks(IFPS_GameplayActions instance)
        {
            @Movement.started -= instance.OnMovement;
            @Movement.performed -= instance.OnMovement;
            @Movement.canceled -= instance.OnMovement;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @Look.started -= instance.OnLook;
            @Look.performed -= instance.OnLook;
            @Look.canceled -= instance.OnLook;
            @Inspect.started -= instance.OnInspect;
            @Inspect.performed -= instance.OnInspect;
            @Inspect.canceled -= instance.OnInspect;
            @Drop.started -= instance.OnDrop;
            @Drop.performed -= instance.OnDrop;
            @Drop.canceled -= instance.OnDrop;
            @Crouch.started -= instance.OnCrouch;
            @Crouch.performed -= instance.OnCrouch;
            @Crouch.canceled -= instance.OnCrouch;
            @Crawl.started -= instance.OnCrawl;
            @Crawl.performed -= instance.OnCrawl;
            @Crawl.canceled -= instance.OnCrawl;
            @Throw.started -= instance.OnThrow;
            @Throw.performed -= instance.OnThrow;
            @Throw.canceled -= instance.OnThrow;
        }

        public void RemoveCallbacks(IFPS_GameplayActions instance)
        {
            if (m_Wrapper.m_FPS_GameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IFPS_GameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_FPS_GameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_FPS_GameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public FPS_GameplayActions @FPS_Gameplay => new FPS_GameplayActions(this);

    // FPS_UI
    private readonly InputActionMap m_FPS_UI;
    private List<IFPS_UIActions> m_FPS_UIActionsCallbackInterfaces = new List<IFPS_UIActions>();
    private readonly InputAction m_FPS_UI_Pause;
    public struct FPS_UIActions
    {
        private @PlayerInputs m_Wrapper;
        public FPS_UIActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_FPS_UI_Pause;
        public InputActionMap Get() { return m_Wrapper.m_FPS_UI; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FPS_UIActions set) { return set.Get(); }
        public void AddCallbacks(IFPS_UIActions instance)
        {
            if (instance == null || m_Wrapper.m_FPS_UIActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_FPS_UIActionsCallbackInterfaces.Add(instance);
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
        }

        private void UnregisterCallbacks(IFPS_UIActions instance)
        {
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
        }

        public void RemoveCallbacks(IFPS_UIActions instance)
        {
            if (m_Wrapper.m_FPS_UIActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IFPS_UIActions instance)
        {
            foreach (var item in m_Wrapper.m_FPS_UIActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_FPS_UIActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public FPS_UIActions @FPS_UI => new FPS_UIActions(this);
    public interface IFPS_GameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnInspect(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
        void OnCrouch(InputAction.CallbackContext context);
        void OnCrawl(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
    }
    public interface IFPS_UIActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
