//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.2.0
//     from Assets/Resources/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""afb7abe4-9d48-4ad5-8077-3cae61735da8"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""32f19b58-5d20-4873-82be-fabb9370dca9"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RotateX"",
                    ""type"": ""Value"",
                    ""id"": ""9fe806f5-d4a0-4b83-a2ca-d0fc5c125a6e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""RotateY"",
                    ""type"": ""Value"",
                    ""id"": ""6f5e9f61-53fc-4bdc-9503-93fe54e7b00e"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""bac89157-4695-4acb-876f-2808ddf14aa6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pick"",
                    ""type"": ""Button"",
                    ""id"": ""7b221499-373a-4d08-a3cf-131f851ffa2b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""36b6d1f7-4818-4a7a-afcd-26581f1d280f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Plant"",
                    ""type"": ""Button"",
                    ""id"": ""6beee4a8-c82c-46cf-a6b1-0e3eeb0e68b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dash"",
                    ""type"": ""Button"",
                    ""id"": ""a99dd26a-0e4a-465b-a387-4a8b43f3d118"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pet"",
                    ""type"": ""Button"",
                    ""id"": ""131ad336-1ef5-461a-866b-2c239d30efb5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Press"",
                    ""type"": ""Button"",
                    ""id"": ""fca1951c-20ee-4faa-baef-5f384a44d51d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Hand"",
                    ""type"": ""Value"",
                    ""id"": ""caf89cc2-5350-46ff-b791-906fd88e8b76"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""48751431-50cf-466f-bdd6-66d568270152"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""398333e1-f8cf-48fe-bc39-40f7307c4e5f"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Game pad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""1732cadb-d311-438f-893b-796e2cb7dc68"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c9e3ce05-d6af-4fe4-acd9-0b9eb4fec76c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a22097a8-2ff8-4cd3-b368-b5613ba28be6"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b6e7be6a-a380-4ca9-a64f-038fe0231940"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b0f53955-e30a-49e6-bfc9-1da31847da32"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""4d35e3c8-2939-4ac4-8400-db17afc0e988"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Game pad"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""befbc173-3c7f-4dba-b76c-9fa816116ad9"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa2a25ef-476d-4a65-89f2-201f797c38fb"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Game pad"",
                    ""action"": ""Pick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c6abef2-cad9-4f0b-94e2-ad80863c2c9d"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f7abe3d8-9ba9-4b65-9e63-4cfbd553d912"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Game pad"",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4140f7c-24ec-40ff-902e-321b6cdde5c0"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Plant"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d1319599-ab68-4202-802f-cdc574063300"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Game pad"",
                    ""action"": ""Plant"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""09e21e45-f7d6-4ec9-bfe6-ad1077317c0e"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Analog"",
                    ""id"": ""4eb629ad-0f73-4e79-bf29-3529b7a252a5"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=-5)"",
                    ""groups"": """",
                    ""action"": ""RotateX"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""8bf29afe-d446-4cfe-9598-3bcea4a437b1"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""170b5bf8-5fd9-4416-8ffc-817e85851936"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c19c0425-49a7-4bab-b9c3-dca715bb2de9"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9f60e17e-234b-47b6-af08-cb9a25e86cee"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Game pad"",
                    ""action"": ""Dash"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9bde5278-861a-432e-afa8-02c4715986cd"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Pet"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a43ddfdb-17b0-4b1f-9156-8b3ba1650425"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Game pad"",
                    ""action"": ""Pet"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e18d9156-3691-4ce3-a0ef-7ea3f8b403e2"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92930dfe-18d7-4ff3-9c1a-ca0634e04ee1"",
                    ""path"": ""<Touchscreen>/primaryTouch/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hand"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7cd0d3dd-2768-4d54-b1dd-20f8d01ffa49"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""feec9607-2cdd-4ba6-86be-e556ce2f6fd5"",
                    ""path"": ""<Touchscreen>/Press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Game pad"",
                    ""action"": ""Press"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee730fa2-a1d9-4be8-a1c0-7b6b889dcfdb"",
                    ""path"": ""<Mouse>/delta/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Analog"",
                    ""id"": ""07474776-0a52-4b9d-b09f-de03b3405809"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": ""Scale(factor=-5)"",
                    ""groups"": """",
                    ""action"": ""RotateY"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""5b03311a-7c15-4cad-8821-a2a8e388f244"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""97c08fe4-5ce6-492a-bed8-306675838508"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Game pad"",
            ""bindingGroup"": ""Game pad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_RotateX = m_Player.FindAction("RotateX", throwIfNotFound: true);
        m_Player_RotateY = m_Player.FindAction("RotateY", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Pick = m_Player.FindAction("Pick", throwIfNotFound: true);
        m_Player_Throw = m_Player.FindAction("Throw", throwIfNotFound: true);
        m_Player_Plant = m_Player.FindAction("Plant", throwIfNotFound: true);
        m_Player_Dash = m_Player.FindAction("Dash", throwIfNotFound: true);
        m_Player_Pet = m_Player.FindAction("Pet", throwIfNotFound: true);
        m_Player_Press = m_Player.FindAction("Press", throwIfNotFound: true);
        m_Player_Hand = m_Player.FindAction("Hand", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_RotateX;
    private readonly InputAction m_Player_RotateY;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Pick;
    private readonly InputAction m_Player_Throw;
    private readonly InputAction m_Player_Plant;
    private readonly InputAction m_Player_Dash;
    private readonly InputAction m_Player_Pet;
    private readonly InputAction m_Player_Press;
    private readonly InputAction m_Player_Hand;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @RotateX => m_Wrapper.m_Player_RotateX;
        public InputAction @RotateY => m_Wrapper.m_Player_RotateY;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Pick => m_Wrapper.m_Player_Pick;
        public InputAction @Throw => m_Wrapper.m_Player_Throw;
        public InputAction @Plant => m_Wrapper.m_Player_Plant;
        public InputAction @Dash => m_Wrapper.m_Player_Dash;
        public InputAction @Pet => m_Wrapper.m_Player_Pet;
        public InputAction @Press => m_Wrapper.m_Player_Press;
        public InputAction @Hand => m_Wrapper.m_Player_Hand;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @RotateX.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateX;
                @RotateX.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateX;
                @RotateX.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateX;
                @RotateY.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateY;
                @RotateY.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateY;
                @RotateY.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotateY;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Pick.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPick;
                @Pick.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPick;
                @Pick.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPick;
                @Throw.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrow;
                @Throw.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrow;
                @Throw.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrow;
                @Plant.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlant;
                @Plant.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlant;
                @Plant.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlant;
                @Dash.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Dash.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDash;
                @Pet.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPet;
                @Pet.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPet;
                @Pet.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPet;
                @Press.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPress;
                @Press.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPress;
                @Press.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPress;
                @Hand.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHand;
                @Hand.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHand;
                @Hand.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHand;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @RotateX.started += instance.OnRotateX;
                @RotateX.performed += instance.OnRotateX;
                @RotateX.canceled += instance.OnRotateX;
                @RotateY.started += instance.OnRotateY;
                @RotateY.performed += instance.OnRotateY;
                @RotateY.canceled += instance.OnRotateY;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Pick.started += instance.OnPick;
                @Pick.performed += instance.OnPick;
                @Pick.canceled += instance.OnPick;
                @Throw.started += instance.OnThrow;
                @Throw.performed += instance.OnThrow;
                @Throw.canceled += instance.OnThrow;
                @Plant.started += instance.OnPlant;
                @Plant.performed += instance.OnPlant;
                @Plant.canceled += instance.OnPlant;
                @Dash.started += instance.OnDash;
                @Dash.performed += instance.OnDash;
                @Dash.canceled += instance.OnDash;
                @Pet.started += instance.OnPet;
                @Pet.performed += instance.OnPet;
                @Pet.canceled += instance.OnPet;
                @Press.started += instance.OnPress;
                @Press.performed += instance.OnPress;
                @Press.canceled += instance.OnPress;
                @Hand.started += instance.OnHand;
                @Hand.performed += instance.OnHand;
                @Hand.canceled += instance.OnHand;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Game pad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotateX(InputAction.CallbackContext context);
        void OnRotateY(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnPick(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
        void OnPlant(InputAction.CallbackContext context);
        void OnDash(InputAction.CallbackContext context);
        void OnPet(InputAction.CallbackContext context);
        void OnPress(InputAction.CallbackContext context);
        void OnHand(InputAction.CallbackContext context);
    }
}
