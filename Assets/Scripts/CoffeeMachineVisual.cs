using UnityEngine;

public class CoffeeMachineVisual : MonoBehaviour
{
    [SerializeField] private CoffeeMachine coffeeMachine;
    [Header("Visuals")]
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite inUseSprite;
    [SerializeField] private Sprite brokenSprite;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        coffeeMachine.OnStateChanged += CoffeeMachine_OnStateChanged;
    }

    private void CoffeeMachine_OnStateChanged(object sender, System.EventArgs e)
    {
        if (coffeeMachine.IsNormal())
        {
            spriteRenderer.sprite = normalSprite;
        }
        else if (coffeeMachine.IsInUse())
        {
            spriteRenderer.sprite = inUseSprite;
        }
        else if (coffeeMachine.IsBroken())
        {
            spriteRenderer.sprite = brokenSprite;
        }
    }
}
