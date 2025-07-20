using UnityEngine;
using UnityEngine.UI;

public class GamePlayingTimerUI : MonoBehaviour
{
    [SerializeField] private Image timer;

    private void Update()
    {
        timer.fillAmount = GameManager.Instance.GetGamePlayingTimerNormalized();
    }
}
