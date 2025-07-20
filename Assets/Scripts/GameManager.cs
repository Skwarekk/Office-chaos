using UnityEngine;

public class GameManager : MonoBehaviour
{
    private enum GameState
    {
        Playing,
        Dialogue,
        GameOver
    }

    public static GameManager Instance { get; private set; }

    private GameState state;
    private float gamePlayingTimer;
    private float gamePlayingTimerMax = 100f;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one instance of GameManager!");
        }
        Instance = this;
    }

    private void Start()
    {
        state = GameState.Playing;
    }

    private void Update()
    {
        if(state == GameState.Playing)
        {
            gamePlayingTimer += Time.deltaTime;

            if (gamePlayingTimer > gamePlayingTimerMax)
            {
                state = GameState.GameOver;
            }
        }
    }

    public void StartDialogue()
    {
        state = GameState.Dialogue;
        GameInput.Instance.DisableMovement();
    }

    public void EndDialogue()
    {
        state = GameState.Playing;
        GameInput.Instance.EnableMovement();
    }

    public float GetGamePlayingTimerNormalized()
    {
        return gamePlayingTimer / gamePlayingTimerMax;
    }
}
