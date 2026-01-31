using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class UserInput : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    private InputSystem_Actions inputs;
    void Awake()
    {
        try
        {
            inputs = new InputSystem_Actions();
            inputs.Player.SetCallbacks(this);
            inputs.Player.Enable();
        }
        catch (Exception exception)
        {
            Debug.LogError($"Error initializing InputManager: {exception.Message}");
        }
    }

    #region Input Events

    // Events that are triggered when input activity is detected
    public event Action<Vector2> MoveInputEvent;
    public event Action<Vector2> LookInputEvent;

    // jumping
    public event Action<InputAction.CallbackContext> JumpInputEvent;
    // sprint
    public event Action<InputAction.CallbackContext> SprintInputEvent;
    // crouch
    public event Action<InputAction.CallbackContext> CrouchInputEvent;
    // attack
    public event Action<InputAction.CallbackContext> AttackInputEvent;
    // interact
    public event Action<InputAction.CallbackContext> InteractInputEvent;

    public event Action<InputAction.CallbackContext> OnPauseInputEvent;
    public event Action<InputAction.CallbackContext> OnJournalInputEvent;
    public event Action<InputAction.CallbackContext> OnMenuOpenCloseInputEvent;

    #endregion

    #region Input Callbacks

    // handle input action callbacks abd dispatches input data to listeners
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveInputEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        LookInputEvent?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        JumpInputEvent?.Invoke(context); 
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        SprintInputEvent?.Invoke(context);
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        CrouchInputEvent?.Invoke(context); 
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        AttackInputEvent?.Invoke(context);
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        InteractInputEvent?.Invoke(context);
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        OnPauseInputEvent?.Invoke(context);
    }
    public void OnJournal(InputAction.CallbackContext context)
    {
        OnJournalInputEvent?.Invoke(context);
    }

    public void OnMenuOpenClose(InputAction.CallbackContext context)
    {
        OnMenuOpenCloseInputEvent?.Invoke(context);
    }

    #endregion

    void OnEnable()
    {
        if (inputs != null)
            inputs.Player.Enable();
    }

    void OnDestroy()
    {
        if (inputs != null)
            inputs.Player.Disable();
    }
}