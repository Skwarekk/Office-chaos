using UnityEngine;
using UnityEngine.UI;

public class ChaosBarUI : MonoBehaviour
{
    [SerializeField] private Image chaosBar;

    private void Start()
    {
        ChaosManager.Instance.OnChaosLevelChanged += Instance_OnChaosLevelChanged;
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        UpdateChaosBar();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsGameOver())
        {
            Hide();
        }
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

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
