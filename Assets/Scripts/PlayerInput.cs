// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInputScriptable.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputScriptable"",
    ""maps"": [
        {
            ""name"": ""OnGround"",
            ""id"": ""d8dcf0b8-ac57-46fc-bf16-358826016a6b"",
            ""actions"": [
                {
                    ""name"": ""Horizontal"",
                    ""type"": ""Button"",
                    ""id"": ""cd965c11-68f6-494e-9c1a-bf95c2885eae"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""8a69625c-20e3-4053-85aa-0f8f3dea1be8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""cd856fce-6934-4b2f-a096-e524e79dd548"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""6e9a3c27-aecd-421c-9829-ba8c3ca11512"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""257a6971-3c3d-46f0-b1da-304e45ef91bf"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""2c23e2c7-fb00-49ce-9115-329593a7acc5"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""c688740a-5ebf-4a83-b53b-b4046901e47f"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""c07b012d-d62b-444f-9b1d-a096a65e9315"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""355c3bc6-0ffa-4b0e-b2ee-a8750c2e17f7"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""defb4ee6-fae3-49fe-b4e2-d29d1a6cd71f"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Horizontal"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f28b861e-dfcd-4fa7-8a5f-d6d314105557"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7181474c-3bf2-4185-aa41-17e8bb3de0ec"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dadef101-eff8-40d3-811f-964449e4ae6d"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e5883747-a6ca-41a6-b1d9-58a2dcaeb071"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f43068bf-45d3-41b2-b4a5-8169c20b47e3"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ba555c6-0c87-427e-a5b7-72215ab64ce5"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e468e88-41b9-4a09-94af-0f76216fdec2"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f6c7562-60b1-4ea3-96ee-775a6de67741"",
                    ""path"": ""<Keyboard>/pause"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InTheAir"",
            ""id"": ""7d3a80bb-c467-44a1-b6d7-7ba885243ed4"",
            ""actions"": [
                {
                    ""name"": ""Delta"",
                    ""type"": ""Button"",
                    ""id"": ""2104c48b-f2a2-4a9c-bd5c-0ecd10cae837"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""9f32a68b-ecf3-4324-a9b6-9a07642ffedf"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""f0c85747-de82-4174-b9c1-901d673db86e"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delta"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""11cf9d9d-993b-4e12-8e2e-dba012cdb82c"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""766a48e5-6e4c-4f27-81a5-acb1aef69057"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a5e48136-99e8-47a8-85e5-733c66eb4437"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9515d1e5-33e3-45a9-8198-a857a48578a0"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""b95574c6-be1d-41fe-9531-fbf21802321a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delta"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""bfb491b1-d8ef-47e2-a886-3353d70cd097"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""08f649ad-cfdc-418e-a8c4-5bca9e26006a"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""03886c4c-1da6-4bf0-8557-a4651ea93642"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9feb034f-bb8a-41e5-a83c-72f6d098a38e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Delta"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6626f065-36aa-4ba1-b433-47d61aa523d4"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b568895a-a0df-4aa6-90bb-7c0d5d09a1c5"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""54c88140-9363-46e8-ae1b-8754e45326fe"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // OnGround
        m_OnGround = asset.FindActionMap("OnGround", throwIfNotFound: true);
        m_OnGround_Horizontal = m_OnGround.FindAction("Horizontal", throwIfNotFound: true);
        m_OnGround_Jump = m_OnGround.FindAction("Jump", throwIfNotFound: true);
        m_OnGround_Interact = m_OnGround.FindAction("Interact", throwIfNotFound: true);
        m_OnGround_Pause = m_OnGround.FindAction("Pause", throwIfNotFound: true);
        // InTheAir
        m_InTheAir = asset.FindActionMap("InTheAir", throwIfNotFound: true);
        m_InTheAir_Delta = m_InTheAir.FindAction("Delta", throwIfNotFound: true);
        m_InTheAir_Interact = m_InTheAir.FindAction("Interact", throwIfNotFound: true);
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

    // OnGround
    private readonly InputActionMap m_OnGround;
    private IOnGroundActions m_OnGroundActionsCallbackInterface;
    private readonly InputAction m_OnGround_Horizontal;
    private readonly InputAction m_OnGround_Jump;
    private readonly InputAction m_OnGround_Interact;
    private readonly InputAction m_OnGround_Pause;
    public struct OnGroundActions
    {
        private @PlayerInput m_Wrapper;
        public OnGroundActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Horizontal => m_Wrapper.m_OnGround_Horizontal;
        public InputAction @Jump => m_Wrapper.m_OnGround_Jump;
        public InputAction @Interact => m_Wrapper.m_OnGround_Interact;
        public InputAction @Pause => m_Wrapper.m_OnGround_Pause;
        public InputActionMap Get() { return m_Wrapper.m_OnGround; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OnGroundActions set) { return set.Get(); }
        public void SetCallbacks(IOnGroundActions instance)
        {
            if (m_Wrapper.m_OnGroundActionsCallbackInterface != null)
            {
                @Horizontal.started -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnHorizontal;
                @Horizontal.performed -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnHorizontal;
                @Horizontal.canceled -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnHorizontal;
                @Jump.started -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnJump;
                @Interact.started -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnInteract;
                @Pause.started -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_OnGroundActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_OnGroundActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Horizontal.started += instance.OnHorizontal;
                @Horizontal.performed += instance.OnHorizontal;
                @Horizontal.canceled += instance.OnHorizontal;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public OnGroundActions @OnGround => new OnGroundActions(this);

    // InTheAir
    private readonly InputActionMap m_InTheAir;
    private IInTheAirActions m_InTheAirActionsCallbackInterface;
    private readonly InputAction m_InTheAir_Delta;
    private readonly InputAction m_InTheAir_Interact;
    public struct InTheAirActions
    {
        private @PlayerInput m_Wrapper;
        public InTheAirActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Delta => m_Wrapper.m_InTheAir_Delta;
        public InputAction @Interact => m_Wrapper.m_InTheAir_Interact;
        public InputActionMap Get() { return m_Wrapper.m_InTheAir; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InTheAirActions set) { return set.Get(); }
        public void SetCallbacks(IInTheAirActions instance)
        {
            if (m_Wrapper.m_InTheAirActionsCallbackInterface != null)
            {
                @Delta.started -= m_Wrapper.m_InTheAirActionsCallbackInterface.OnDelta;
                @Delta.performed -= m_Wrapper.m_InTheAirActionsCallbackInterface.OnDelta;
                @Delta.canceled -= m_Wrapper.m_InTheAirActionsCallbackInterface.OnDelta;
                @Interact.started -= m_Wrapper.m_InTheAirActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_InTheAirActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_InTheAirActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_InTheAirActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Delta.started += instance.OnDelta;
                @Delta.performed += instance.OnDelta;
                @Delta.canceled += instance.OnDelta;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public InTheAirActions @InTheAir => new InTheAirActions(this);
    public interface IOnGroundActions
    {
        void OnHorizontal(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IInTheAirActions
    {
        void OnDelta(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}
