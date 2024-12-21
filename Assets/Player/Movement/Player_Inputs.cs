//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Player/Movement/Player_Inputs.inputactions
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

public partial class @Player_Inputs: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player_Inputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player_Inputs"",
    ""maps"": [
        {
            ""name"": ""Player_Movement"",
            ""id"": ""5de62903-2625-4697-b2ab-072fd741508d"",
            ""actions"": [
                {
                    ""name"": ""WASD"",
                    ""type"": ""Value"",
                    ""id"": ""628e2d6e-9b61-4864-9f36-eb85fed49b49"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""62a53d31-1a5b-4a7c-9248-0c6c470c6f1d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""feb4afe5-3244-436f-baa2-3a2d29f18fde"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""bf46d0ee-67fd-4a48-8749-e4a992aba615"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""63055f36-fd4a-45d6-b3ad-2ccf7d2a738b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""06b0b1c7-091a-43ed-9044-a9a21493bbef"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""WASD"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player_Movement
        m_Player_Movement = asset.FindActionMap("Player_Movement", throwIfNotFound: true);
        m_Player_Movement_WASD = m_Player_Movement.FindAction("WASD", throwIfNotFound: true);
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

    // Player_Movement
    private readonly InputActionMap m_Player_Movement;
    private List<IPlayer_MovementActions> m_Player_MovementActionsCallbackInterfaces = new List<IPlayer_MovementActions>();
    private readonly InputAction m_Player_Movement_WASD;
    public struct Player_MovementActions
    {
        private @Player_Inputs m_Wrapper;
        public Player_MovementActions(@Player_Inputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @WASD => m_Wrapper.m_Player_Movement_WASD;
        public InputActionMap Get() { return m_Wrapper.m_Player_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player_MovementActions set) { return set.Get(); }
        public void AddCallbacks(IPlayer_MovementActions instance)
        {
            if (instance == null || m_Wrapper.m_Player_MovementActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_Player_MovementActionsCallbackInterfaces.Add(instance);
            @WASD.started += instance.OnWASD;
            @WASD.performed += instance.OnWASD;
            @WASD.canceled += instance.OnWASD;
        }

        private void UnregisterCallbacks(IPlayer_MovementActions instance)
        {
            @WASD.started -= instance.OnWASD;
            @WASD.performed -= instance.OnWASD;
            @WASD.canceled -= instance.OnWASD;
        }

        public void RemoveCallbacks(IPlayer_MovementActions instance)
        {
            if (m_Wrapper.m_Player_MovementActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayer_MovementActions instance)
        {
            foreach (var item in m_Wrapper.m_Player_MovementActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_Player_MovementActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public Player_MovementActions @Player_Movement => new Player_MovementActions(this);
    public interface IPlayer_MovementActions
    {
        void OnWASD(InputAction.CallbackContext context);
    }
}