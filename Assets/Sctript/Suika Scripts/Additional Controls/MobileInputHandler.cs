using UnityEngine;

public class MobileInputHandler : MonoBehaviour
{
    public static MobileInputHandler instance;

    [HideInInspector] public bool IsLeftPressed = false;
    [HideInInspector] public bool IsRightPressed = false;
    [HideInInspector] public bool IsThrowPressed = false;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void OnLeftButtonDown() => IsLeftPressed = true;
    public void OnLeftButtonUp() => IsLeftPressed = false;

    public void OnRightButtonDown() => IsRightPressed = true;
    public void OnRightButtonUp() => IsRightPressed = false;

    public void OnThrowButtonPressed() => IsThrowPressed = true;

    private void LateUpdate()
    {
        // Reset one-frame action
        IsThrowPressed = false;
    }
}
