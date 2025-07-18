using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnNextDialogue;

    public static GameInput Instance { get; private set; }
    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("There is more than one instance of GameInput!");
        }
        Instance = this;

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    private void Start()
    {
        playerInputActions.Player.SkipDialogue.performed += SkipDialogue_performed;
    }

    private void SkipDialogue_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnNextDialogue?.Invoke(this, EventArgs.Empty);
    }

    public float GetMovementValue()
    {
        return playerInputActions.Player.Move.ReadValue<float>();
    }

    public void DisableMovement()
    {
        playerInputActions.Player.Move.Disable();
    }

    public void EnableMovement()
    {
        playerInputActions.Player.Move.Enable();
    }
}
