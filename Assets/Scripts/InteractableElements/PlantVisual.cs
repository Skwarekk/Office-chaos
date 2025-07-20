using UnityEngine;

public class PlantVisual : MonoBehaviour
{
    [SerializeField] private Plant plant;
    [Header("Visuals")]
    [SerializeField] private Sprite firstPhaseSprite;
    [SerializeField] private Sprite secondPhaseSprite;
    [SerializeField] private Sprite thirdPhaseSprite;
    [SerializeField] private Sprite fourthPhaseSprite;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        plant.OnStateChanged += Plant_OnStateChanged;
    }

    private void Plant_OnStateChanged(object sender, System.EventArgs e)
    {
        if (plant.IsFirstPhase())
        {
            spriteRenderer.sprite = firstPhaseSprite;
        }
        else if (plant.IsSecondPhase())
        {
            spriteRenderer.sprite = secondPhaseSprite;
        }
        else if (plant.IsThirdPhase())
        {
            spriteRenderer.sprite = thirdPhaseSprite;
        }
        else if (plant.IsFourthPhase())
        {
            spriteRenderer.sprite = fourthPhaseSprite;
        }
    }
}
