using UnityEngine;
using UnityEngine.UI;

public class GamePlayingTimerUI : MonoBehaviour
{
    [SerializeField] private Image timer;

    private void Start()
    {
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsGameOver())
        {
            Hide();
        }
    }

    private void Update()
    {
        timer.fillAmount = GameManager.Instance.GetGamePlayingTimerNormalized();
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
