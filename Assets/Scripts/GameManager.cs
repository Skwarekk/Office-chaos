using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event EventHandler OnStateChanged;

    private enum GameState
    {
        Playing,
        Dialogue,
        GameOver,
        GameWin
    }

    public static GameManager Instance { get; private set; }

    private GameState state;
    private float gamePlayingTimer;
    private float gamePlayingTimerMax = 30f;

    private bool isDialogueActive = false;
    private bool isGameOverActive = false;
    private bool isGameWinActive = false;

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
        ChaosManager.Instance.OnChaosLevelMaxed += ChaosManager_OnChaosLevelMaxed;
    }

    private void ChaosManager_OnChaosLevelMaxed(object sender, EventArgs e)
    {
        state = GameState.GameOver;
        isGameWinActive = true;
    }

    private void Update()
    {
        if ((IsGameOver() || IsGameWin()) && !isDialogueActive)
        {
            OnStateChanged?.Invoke(this, EventArgs.Empty);
        }

        if (state == GameState.Playing)
        {
            gamePlayingTimer += Time.deltaTime;

            if (gamePlayingTimer > gamePlayingTimerMax)
            {
                state = GameState.GameOver;
                isGameOverActive = true;
            }
        }
    }

    public void StartDialogue()
    {
        isDialogueActive = true;
        state = GameState.Dialogue;
        GameInput.Instance.DisableMovement();
    }

    public void EndDialogue()
    {
        isDialogueActive = false;

        if (isGameOverActive)
        {
            state = GameState.GameOver;
        }
        else if (isGameWinActive)
        {
            state = GameState.GameWin;
        }
        else
        {
            state = GameState.Playing;
        }
        GameInput.Instance.EnableMovement();
    }

    public float GetGamePlayingTimer()
    {
        return gamePlayingTimer;
    }

    public float GetGamePlayingTimerNormalized()
    {
        return gamePlayingTimer / gamePlayingTimerMax;
    }

    public bool IsGameOver()
    {
        return state == GameState.GameOver;
    }

    public bool IsGameWin()
    {
        return state == GameState.GameWin;
    }
}
