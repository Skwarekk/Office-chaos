using UnityEngine;

public class GameInput : MonoBehaviour
{
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

    public float GetMovementValue()
    {
        return playerInputActions.Player.Move.ReadValue<float>();
    }
}
