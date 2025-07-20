using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreenUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI chaosLevelText;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;

    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;

        restartButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameScene);
        });

        mainMenuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });

        Hide();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsGameOver())
        {
            Show();
            chaosLevelText.text = ChaosManager.Instance.GetChaosLevel().ToString();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
