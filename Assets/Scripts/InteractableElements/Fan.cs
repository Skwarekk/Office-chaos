using System;
using UnityEngine;

public class Fan : InteractableElement
{
    public event EventHandler OnStateChanged;

    private enum State
    {
        Normal,
        InUse,
        Used
    }

    [SerializeField] private string[] tornadoLines;
    [Space]
    [SerializeField] private float usingTime = 2f;
    [Header("Tornado")]
    [SerializeField] private Transform tornadoPrefab;
    [SerializeField] private Transform tornadoStarterPoint;
    private float timer;

    private State state;

    public override void Interact()
    {
        state = State.InUse;
        ToggleIsInUse();
        OnStateChanged?.Invoke(this, EventArgs.Empty);
    }

    private void Start()
    {
        state = State.Normal;
    }

    private void Update()
    {
        if (state == State.InUse)
        {
            timer += Time.deltaTime;

            if (timer > usingTime)
            {
                state = State.Used;
                ToggleIsInUse();
                OnStateChanged?.Invoke(this, EventArgs.Empty);
                ToggleCanInteract();
                DialogueManager.Instance.ShowDialogue(tornadoLines);
                ChaosManager.Instance.IncreaseChaosLevel(GetChaosAmount());
                Instantiate(tornadoPrefab, tornadoStarterPoint);
            }
        }
    }

    // Methods to check the state of the fan

    public bool IsNormal()
    {
        return state == State.Normal;
    }

    public bool IsInUse()
    {
        return state == State.InUse;
    }

    public bool IsTornado()
    {
        return state == State.Used;
    }
}
