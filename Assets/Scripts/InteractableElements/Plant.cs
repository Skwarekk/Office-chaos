using System;
using UnityEngine;

public class Plant : InteractableElement
{
    public event EventHandler OnStateChanged;
    public event EventHandler OnInteract;

    private enum State
    {
        Normal,
        FirstPhase,
        SecondPhase,
        ThirdPhase,
        FourthPhase,
        InUse
    }

    public static Plant Instance { get; private set; }

    [SerializeField] private string[] firstPhaseLines;
    [SerializeField] private string[] secondPhaseLines;
    [SerializeField] private string[] thirdPhaseLines;
    [SerializeField] private string[] fourthPhaseLines;
    [SerializeField] private string[] finalPhaseLines;
    [Space]
    [SerializeField] private float phaseTime = 2f;

    private State state;
    private State targetState;
    private float phaseTimer;

    public override void Interact()
    {
        OnInteract?.Invoke(this, EventArgs.Empty);
        switch (state)
        {
            case State.Normal:
                GoToPhase(State.FirstPhase);
                break;
            case State.FirstPhase:
                GoToPhase(State.SecondPhase);
                break;
            case State.SecondPhase:
                GoToPhase(State.ThirdPhase);
                break;
            case State.ThirdPhase:
                GoToPhase(State.FourthPhase);
                break;
            case State.FourthPhase:
                ToggleCanInteract();
                break;
            default:
                break;
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("There is more than one Instance of Plant!");
        }
        Instance = this;
    }

    private void Start()
    {
        state = State.Normal;
    }

    private void Update()
    {
        if (state == State.InUse)
        {
            phaseTimer += Time.deltaTime;

            if (phaseTimer > phaseTime)
            {
                phaseTimer = 0f;
                state = targetState;
                OnStateChanged?.Invoke(this, EventArgs.Empty);
                ShowCorrectDialogue();
                if (state == State.FourthPhase)
                {
                    ChaosManager.Instance.IncreaseChaosLevel(GetChaosAmount());
                }
                ToggleIsInUse();
            }
        }
    }

    private void GoToPhase(State state)
    {
        ToggleIsInUse();
        targetState = state;
        this.state = State.InUse;
    }

    private void ShowCorrectDialogue()
    {
        switch (state)
        {
            case State.FirstPhase:
                DialogueManager.Instance.ShowDialogue(firstPhaseLines);
                break;
            case State.SecondPhase:
                DialogueManager.Instance.ShowDialogue(secondPhaseLines);
                break;
            case State.ThirdPhase:
                DialogueManager.Instance.ShowDialogue(thirdPhaseLines);
                break;
            case State.FourthPhase:
                DialogueManager.Instance.ShowDialogue(fourthPhaseLines);
                DialogueManager.Instance.ShowDialogue(finalPhaseLines);
                break;
            default:
                break;
        }
    }

    public bool IsFirstPhase()
    {
        return state == State.FirstPhase;
    }

    public bool IsSecondPhase()
    {
        return state == State.SecondPhase;
    }

    public bool IsThirdPhase()
    {
        return state == State.ThirdPhase;
    }

    public bool IsFourthPhase()
    {
        return state == State.FourthPhase;
    }
}
