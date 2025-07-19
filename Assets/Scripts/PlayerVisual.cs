using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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

        animator.SetBool(IS_WALKING, Player.Instance.IsWalking());
    }
}
