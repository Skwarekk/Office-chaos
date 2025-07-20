using UnityEngine;

public class FanVisual : MonoBehaviour
{
    [SerializeField] private Fan fan;
    [Header("Visuals")]
    [SerializeField] private Sprite normalSprite;
    [SerializeField] private Sprite inUseSprite;
    [Header("Tornado")]
    [SerializeField] private Transform tornadoPrefab;
    [SerializeField] private Transform tornadoStarterPoint;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        fan.OnStateChanged += Fan_OnStateChanged;
    }

    private void Fan_OnStateChanged(object sender, System.EventArgs e)
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
            Instantiate(tornadoPrefab, tornadoStarterPoint);
            spriteRenderer.sprite = normalSprite;
        }
    }
}
