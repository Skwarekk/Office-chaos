using UnityEngine;

public class FanVisual : MonoBehaviour
{
    [SerializeField] private Fan fan;
    [Header("Visuals")]
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite inUseSprite;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        fan.OnStateChanged += CoffeeMachine_OnStateChanged;
    }

    private void CoffeeMachine_OnStateChanged(object sender, System.EventArgs e)
    {
        if (fan.IsNormal())
        {
            spriteRenderer.sprite = normalSprite;
        }
        else if (fan.IsInUse())
        {
            spriteRenderer.sprite = inUseSprite;
        }
        else if (fan.IsTornado())
        {
            spriteRenderer.sprite = normalSprite;
        }
    }
}
