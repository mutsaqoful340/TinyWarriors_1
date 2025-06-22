using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static PlayerInput PlayerInput;

    public static Vector2 MoveInput { get; set; }

    public static bool IsThrowPressed { get; set; }

    private InputAction _moveAction;
    private InputAction _throwAction;

    private void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();

        _moveAction = PlayerInput.actions["Move"];
        _throwAction = PlayerInput.actions["Throw"];
    }

    private void Update()
    {
        // Default to Input System values
        Vector2 moveValue = _moveAction.ReadValue<Vector2>();
        bool throwPressed = _throwAction.WasPressedThisFrame();

        // Override if mobile buttons are used
        if (MobileInputHandler.instance != null)
        {
            if (MobileInputHandler.instance.IsLeftPressed)
                moveValue.x = -1;
            else if (MobileInputHandler.instance.IsRightPressed)
                moveValue.x = 1;
            else if (!throwPressed)
                moveValue.x = 0;

            if (MobileInputHandler.instance.IsThrowPressed)
                throwPressed = true;
        }

        MoveInput = moveValue;
        IsThrowPressed = throwPressed;
    }
}
