using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [SerializeField] private float speed = 7f;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one instance if Player!");
        }
        Instance = this;
    }

    private void Update()
    {
        float movementValue = GameInput.Instance.GetMovementValue();
        Vector3 movement = new Vector3(movementValue, 0, 0);
        transform.Translate(movement * speed * Time.deltaTime);
    }

    public bool IsWalking()
    {
        return GameInput.Instance.GetMovementValue() != 0;
    }
}
