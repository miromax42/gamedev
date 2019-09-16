// GENERATED AUTOMATICALLY FROM 'Assets/plControl.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlControl : IInputActionCollection
{
    private InputActionAsset asset;
    public PlControl()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""plControl"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""cb278489-d599-4e96-aaf5-ecc39ac54d49"",
            ""actions"": [
                {
                    ""name"": ""Grow"",
                    ""type"": ""Button"",
                    ""id"": ""317f0e3b-2887-4069-a532-273e15791b10"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""eea81105-b08f-42ff-8335-59e197e55cc9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotation"",
                    ""type"": ""Button"",
                    ""id"": ""a7d52129-2ab7-427c-b1f6-d695d3c8c515"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""07d1a761-dfc4-45e0-828d-b98b7a942614"",
                    ""path"": ""<XInputController>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57806153-0042-4ed2-a398-857e1a438812"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Grow"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""703cda94-52a9-4435-980e-9ec9759b5aee"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a61aa47f-66ae-451a-9b36-680ee63996bc"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.GetActionMap("Gameplay");
        m_Gameplay_Grow = m_Gameplay.GetAction("Grow");
        m_Gameplay_Move = m_Gameplay.GetAction("Move");
        m_Gameplay_Rotation = m_Gameplay.GetAction("Rotation");
    }

    ~PlControl()
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Grow;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Rotation;
    public struct GameplayActions
    {
        private PlControl m_Wrapper;
        public GameplayActions(PlControl wrapper) { m_Wrapper = wrapper; }
        public InputAction @Grow => m_Wrapper.m_Gameplay_Grow;
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Rotation => m_Wrapper.m_Gameplay_Rotation;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                Grow.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrow;
                Grow.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrow;
                Grow.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnGrow;
                Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                Rotation.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotation;
                Rotation.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotation;
                Rotation.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRotation;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                Grow.started += instance.OnGrow;
                Grow.performed += instance.OnGrow;
                Grow.canceled += instance.OnGrow;
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                Rotation.started += instance.OnRotation;
                Rotation.performed += instance.OnRotation;
                Rotation.canceled += instance.OnRotation;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnGrow(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnRotation(InputAction.CallbackContext context);
    }
}
