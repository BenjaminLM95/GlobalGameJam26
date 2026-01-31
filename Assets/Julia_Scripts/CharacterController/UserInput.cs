using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static UserInput Instance { get; private set; }

    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; }
    public bool JumpJustPressed { get; private set; }
    public bool MainInput { get; private set; }
    public bool RunInput { get; private set; }
    public bool MenuOpenCloseInput { get; private set; }
    public bool CancelInput { get; private set; }
    public bool AttackInput { get; private set; }
    public bool InteractInput { get; private set; }
    public bool CrouchInput { get; private set; }

    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _lookAction;
    private InputAction _jumpAction;
    private InputAction _runAction;
    private InputAction _attackAction;
    private InputAction _interactAction;
    private InputAction _crouchAction;

    InputAction moveAction;
    Vector2 lookRotation;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        _playerInput = GetComponent<PlayerInput>();

        SetupInputActions();
    }

    private void Update()
    {
        UpdateInputs();
    }

    private void SetupInputActions()
    {

        _moveAction = _playerInput.actions["Move"];

        _lookAction = _playerInput.actions["Look"];

        _attackAction = _playerInput.actions["Attack"];

        _interactAction = _playerInput.actions["Interact"];

        _crouchAction = _playerInput.actions["Crouch"];

        _jumpAction = _playerInput.actions["Jump"];

        _runAction = _playerInput.actions["Sprint"];
    }

    private void UpdateInputs()
    {

        MoveInput = _moveAction.ReadValue<Vector2>();

        LookInput = _lookAction.ReadValue<Vector2>();

        JumpJustPressed = _jumpAction.WasPressedThisFrame();

        RunInput = _runAction.IsPressed();

        AttackInput = _attackAction.WasPressedThisFrame();

        InteractInput = _interactAction.WasPressedThisFrame();

        CrouchInput = _crouchAction.WasPressedThisFrame();
    }
}