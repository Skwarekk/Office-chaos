using UnityEngine;
using UnityEngine.UI;

public class ChaosBarUI : MonoBehaviour
{
    [SerializeField] private Image chaosBar;

    private void Start()
    {
        ChaosManager.Instance.OnChaosLevelChanged += Instance_OnChaosLevelChanged;
        UpdateChaosBar();
    }

    private void Instance_OnChaosLevelChanged(object sender, System.EventArgs e)
    {
        UpdateChaosBar();
    }

    private void UpdateChaosBar()
    {
        float chaosLevelNormalized = ChaosManager.Instance.GetChaosLevel() / 100f;
        chaosBar.fillAmount = chaosLevelNormalized;
    }
}
