using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float movementValue = GameInput.Instance.GetMovementValue();

        if (movementValue > 0)
        {
            spriteRenderer.flipX = false; // Facing right
        }
        else if (movementValue < 0)
        {
            spriteRenderer.flipX = true; // Facing left
        }
    }
}
