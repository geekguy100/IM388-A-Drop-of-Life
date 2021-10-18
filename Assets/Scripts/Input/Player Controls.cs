// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/Player Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Controls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""714eb0bd-099c-4597-b1cb-6522ddca2831"",
            ""actions"": [
                {
                    ""name"": ""MouseMove"",
                    ""type"": ""Value"",
                    ""id"": ""5d7188c3-f747-426c-a61f-0b2db6d19f13"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""8894d885-11ca-4cde-a8cc-503404cd3e9c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""204f2596-eaa1-4dbd-820f-7ea043980e6a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a46ab78f-2bda-42ae-aa14-c688b8c1fac0"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""e1757253-2592-415e-9d70-42df7ee0798a"",
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
                    ""id"": ""2a9d1e2f-80a7-4cc8-93b6-7ba8f68b2fba"",
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
                    ""id"": ""6d8bfa55-6f12-4eb9-991d-d8fb47696ea4"",
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
                    ""id"": ""837e9e66-d643-426f-94fa-72d1cde536fd"",
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
                    ""id"": ""995e37d9-5d98-492e-b283-31772d085ac1"",
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
                    ""id"": ""50d3c07d-d00a-430b-8b18-8c99adb34709"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""WeaponsHandling"",
            ""id"": ""53f2871f-6d5d-4f7c-b6a5-8fa339ab4700"",
            ""actions"": [
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""f5253cc8-e9cb-4a1a-98ca-4eb6a7ea87b3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""f7dd7ec6-b60c-4286-a135-6ea30849f57c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""Button"",
                    ""id"": ""59280cb6-7627-4799-94de-499525c3a85b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e9945b98-efc7-4f12-875a-bfec183d95b2"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5e732c8-ac2c-46bb-a346-4a4eef558718"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""896869a0-19b4-4688-86f9-ffb2b8c47580"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""StatesOfMatter"",
            ""id"": ""9ea0628a-accf-462e-8b4f-e643881e7d85"",
            ""actions"": [
                {
                    ""name"": ""Default State"",
                    ""type"": ""Button"",
                    ""id"": ""b6c97604-80c6-4f3f-8860-272de1acad1e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""State 1"",
                    ""type"": ""Button"",
                    ""id"": ""69ebc6b1-caf0-4f7e-9b79-074094ffc886"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""State 2"",
                    ""type"": ""Button"",
                    ""id"": ""791638c4-7a59-491c-a6b0-f1030e434f5d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""State 3"",
                    ""type"": ""Button"",
                    ""id"": ""3352f00c-ff57-4c3a-94b9-00405c2cc7a2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1aa7637d-7697-4427-81e9-ae548a3e0770"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Default State"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6a1031c-16c9-47cc-9d38-047efec87ed5"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""State 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""088c65b3-18d6-4666-86fe-a600ef841e2c"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""State 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d9483c20-73f1-4a1c-a3dc-d4effb38d28d"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""State 3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Interaction"",
            ""id"": ""7594f908-eb4f-4c36-a8c5-80efcf6db6cc"",
            ""actions"": [
                {
                    ""name"": ""InteractStateSwap"",
                    ""type"": ""Button"",
                    ""id"": ""c13a2b99-e2da-40d2-a085-879e0c05ebfe"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""9d9eca18-8dbf-4dca-a1da-b0a2dcae9714"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e0066238-3fa0-4a90-8a77-2e359d99cc2d"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InteractStateSwap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18cce786-24f9-46d0-837b-7f6510ece529"",
                    ""path"": ""<Keyboard>/e"",
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
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_MouseMove = m_Player.FindAction("MouseMove", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        // WeaponsHandling
        m_WeaponsHandling = asset.FindActionMap("WeaponsHandling", throwIfNotFound: true);
        m_WeaponsHandling_Fire = m_WeaponsHandling.FindAction("Fire", throwIfNotFound: true);
        m_WeaponsHandling_Reload = m_WeaponsHandling.FindAction("Reload", throwIfNotFound: true);
        m_WeaponsHandling_Aim = m_WeaponsHandling.FindAction("Aim", throwIfNotFound: true);
        // StatesOfMatter
        m_StatesOfMatter = asset.FindActionMap("StatesOfMatter", throwIfNotFound: true);
        m_StatesOfMatter_DefaultState = m_StatesOfMatter.FindAction("Default State", throwIfNotFound: true);
        m_StatesOfMatter_State1 = m_StatesOfMatter.FindAction("State 1", throwIfNotFound: true);
        m_StatesOfMatter_State2 = m_StatesOfMatter.FindAction("State 2", throwIfNotFound: true);
        m_StatesOfMatter_State3 = m_StatesOfMatter.FindAction("State 3", throwIfNotFound: true);
        // Interaction
        m_Interaction = asset.FindActionMap("Interaction", throwIfNotFound: true);
        m_Interaction_InteractStateSwap = m_Interaction.FindAction("InteractStateSwap", throwIfNotFound: true);
        m_Interaction_Interact = m_Interaction.FindAction("Interact", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_MouseMove;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Jump;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseMove => m_Wrapper.m_Player_MouseMove;
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @MouseMove.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseMove;
                @MouseMove.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseMove;
                @MouseMove.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMouseMove;
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseMove.started += instance.OnMouseMove;
                @MouseMove.performed += instance.OnMouseMove;
                @MouseMove.canceled += instance.OnMouseMove;
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // WeaponsHandling
    private readonly InputActionMap m_WeaponsHandling;
    private IWeaponsHandlingActions m_WeaponsHandlingActionsCallbackInterface;
    private readonly InputAction m_WeaponsHandling_Fire;
    private readonly InputAction m_WeaponsHandling_Reload;
    private readonly InputAction m_WeaponsHandling_Aim;
    public struct WeaponsHandlingActions
    {
        private @PlayerControls m_Wrapper;
        public WeaponsHandlingActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Fire => m_Wrapper.m_WeaponsHandling_Fire;
        public InputAction @Reload => m_Wrapper.m_WeaponsHandling_Reload;
        public InputAction @Aim => m_Wrapper.m_WeaponsHandling_Aim;
        public InputActionMap Get() { return m_Wrapper.m_WeaponsHandling; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WeaponsHandlingActions set) { return set.Get(); }
        public void SetCallbacks(IWeaponsHandlingActions instance)
        {
            if (m_Wrapper.m_WeaponsHandlingActionsCallbackInterface != null)
            {
                @Fire.started -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnFire;
                @Reload.started -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnReload;
                @Aim.started -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_WeaponsHandlingActionsCallbackInterface.OnAim;
            }
            m_Wrapper.m_WeaponsHandlingActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
            }
        }
    }
    public WeaponsHandlingActions @WeaponsHandling => new WeaponsHandlingActions(this);

    // StatesOfMatter
    private readonly InputActionMap m_StatesOfMatter;
    private IStatesOfMatterActions m_StatesOfMatterActionsCallbackInterface;
    private readonly InputAction m_StatesOfMatter_DefaultState;
    private readonly InputAction m_StatesOfMatter_State1;
    private readonly InputAction m_StatesOfMatter_State2;
    private readonly InputAction m_StatesOfMatter_State3;
    public struct StatesOfMatterActions
    {
        private @PlayerControls m_Wrapper;
        public StatesOfMatterActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @DefaultState => m_Wrapper.m_StatesOfMatter_DefaultState;
        public InputAction @State1 => m_Wrapper.m_StatesOfMatter_State1;
        public InputAction @State2 => m_Wrapper.m_StatesOfMatter_State2;
        public InputAction @State3 => m_Wrapper.m_StatesOfMatter_State3;
        public InputActionMap Get() { return m_Wrapper.m_StatesOfMatter; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StatesOfMatterActions set) { return set.Get(); }
        public void SetCallbacks(IStatesOfMatterActions instance)
        {
            if (m_Wrapper.m_StatesOfMatterActionsCallbackInterface != null)
            {
                @DefaultState.started -= m_Wrapper.m_StatesOfMatterActionsCallbackInterface.OnDefaultState;
                @DefaultState.performed -= m_Wrapper.m_StatesOfMatterActionsCallbackInterface.OnDefaultState;
                @DefaultState.canceled -= m_Wrapper.m_StatesOfMatterActionsCallbackInterface.OnDefaultState;
                @State1.started -= m_Wrapper.m_StatesOfMatterActionsCallbackInterface.OnState1;
                @State1.performed -= m_Wrapper.m_StatesOfMatterActionsCallbackInterface.OnState1;
                @State1.canceled -= m_Wrapper.m_StatesOfMatterActionsCallbackInterface.OnState1;
                @State2.started -= m_Wrapper.m_StatesOfMatterActionsCallbackInterface.OnState2;
                @State2.performed -= m_Wrapper.m_StatesOfMatterActionsCallbackInterface.OnState2;
                @State2.canceled -= m_Wrapper.m_StatesOfMatterActionsCallbackInterface.OnState2;
                @State3.started -= m_Wrapper.m_StatesOfMatterActionsCallbackInterface.OnState3;
                @State3.performed -= m_Wrapper.m_StatesOfMatterActionsCallbackInterface.OnState3;
                @State3.canceled -= m_Wrapper.m_StatesOfMatterActionsCallbackInterface.OnState3;
            }
            m_Wrapper.m_StatesOfMatterActionsCallbackInterface = instance;
            if (instance != null)
            {
                @DefaultState.started += instance.OnDefaultState;
                @DefaultState.performed += instance.OnDefaultState;
                @DefaultState.canceled += instance.OnDefaultState;
                @State1.started += instance.OnState1;
                @State1.performed += instance.OnState1;
                @State1.canceled += instance.OnState1;
                @State2.started += instance.OnState2;
                @State2.performed += instance.OnState2;
                @State2.canceled += instance.OnState2;
                @State3.started += instance.OnState3;
                @State3.performed += instance.OnState3;
                @State3.canceled += instance.OnState3;
            }
        }
    }
    public StatesOfMatterActions @StatesOfMatter => new StatesOfMatterActions(this);

    // Interaction
    private readonly InputActionMap m_Interaction;
    private IInteractionActions m_InteractionActionsCallbackInterface;
    private readonly InputAction m_Interaction_InteractStateSwap;
    private readonly InputAction m_Interaction_Interact;
    public struct InteractionActions
    {
        private @PlayerControls m_Wrapper;
        public InteractionActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @InteractStateSwap => m_Wrapper.m_Interaction_InteractStateSwap;
        public InputAction @Interact => m_Wrapper.m_Interaction_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Interaction; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InteractionActions set) { return set.Get(); }
        public void SetCallbacks(IInteractionActions instance)
        {
            if (m_Wrapper.m_InteractionActionsCallbackInterface != null)
            {
                @InteractStateSwap.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteractStateSwap;
                @InteractStateSwap.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteractStateSwap;
                @InteractStateSwap.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteractStateSwap;
                @Interact.started -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_InteractionActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_InteractionActionsCallbackInterface = instance;
            if (instance != null)
            {
                @InteractStateSwap.started += instance.OnInteractStateSwap;
                @InteractStateSwap.performed += instance.OnInteractStateSwap;
                @InteractStateSwap.canceled += instance.OnInteractStateSwap;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public InteractionActions @Interaction => new InteractionActions(this);
    public interface IPlayerActions
    {
        void OnMouseMove(InputAction.CallbackContext context);
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IWeaponsHandlingActions
    {
        void OnFire(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
    }
    public interface IStatesOfMatterActions
    {
        void OnDefaultState(InputAction.CallbackContext context);
        void OnState1(InputAction.CallbackContext context);
        void OnState2(InputAction.CallbackContext context);
        void OnState3(InputAction.CallbackContext context);
    }
    public interface IInteractionActions
    {
        void OnInteractStateSwap(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}
