using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    List<IInputUser> Subscribers = new();
    PlayerInputActions inputActions;

    static InputSystem instance;

    void Awake()
    {
        instance = this;

        inputActions = new PlayerInputActions();
        inputActions.Enable();
        inputActions.Player.Jump.performed += JumpInput;
        inputActions.Player.Pick.performed += PickInput;
        inputActions.Player.Throw.performed += ThrowInput;
        inputActions.Player.Plant.performed += PlantInput;
        inputActions.Player.Dash.performed += DashInput;
        inputActions.Player.Pet.performed += PetInput;
        inputActions.Player.Press.performed += PressInput;
    }
    void FixedUpdate()
    {
        MovementInput();
        RotateInput();
    }

    public static void SubscribeUser(IInputUser user)
    {
        instance.Subscribers.Add(user);
    }
    public static Vector2 GetMousePosition()
    {
        return instance.inputActions.Player.Hand.ReadValue<Vector2>();
    }


    void PickInput(InputAction.CallbackContext obj)
    {
        foreach(IInputUser sub in Subscribers)
            sub.PickInput();
    }
    void JumpInput(InputAction.CallbackContext context)
    {
        foreach (IInputUser sub in Subscribers)
            sub.JumpInput();
    }
    void ThrowInput(InputAction.CallbackContext obj)
    {
        foreach (IInputUser sub in Subscribers)
            sub.ThrowInput();
    }
    void PlantInput(InputAction.CallbackContext obj)
    {
        foreach (IInputUser sub in Subscribers)
            sub.PlantInput();
    }
    void DashInput(InputAction.CallbackContext obj)
    {
        foreach (IInputUser sub in Subscribers)
            sub.DashInput();
    }
    void PetInput(InputAction.CallbackContext obj)
    {
        foreach (IInputUser sub in Subscribers)
            sub.PetInput();
    }
    void PressInput(InputAction.CallbackContext obj)
    {
        foreach (IInputUser sub in Subscribers)
            sub.PressInput();
    }
    void MovementInput()
    {
        Vector2 xyAxis = inputActions.Player.Move.ReadValue<Vector2>();

        if (xyAxis.magnitude > 0)
        {
            foreach (IInputUser sub in Subscribers)
                sub.MoveInput(xyAxis);
        }
    }
    void RotateInput()
    {
        Vector2 deltaRotate = new Vector2();

        deltaRotate.x = inputActions.Player.RotateX.ReadValue<float>();
        deltaRotate.y = inputActions.Player.RotateY.ReadValue<float>();

        if (deltaRotate.magnitude > 0)
        {
            foreach (IInputUser sub in Subscribers)
                sub.RotateInput(deltaRotate);
        }
    }
}

