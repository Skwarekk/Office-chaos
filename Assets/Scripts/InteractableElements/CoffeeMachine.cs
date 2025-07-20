using System;
using UnityEngine;

public class CoffeeMachine : InteractableElement
{
    public event EventHandler OnStateChanged;

    private enum State
    {
        Normal,
        InUse,
        Broken
    }

    [SerializeField] private string[] coffeOnTheFloorLines;
    [Space]
    [SerializeField] private float timeToBrew = 1.5f;
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

            if (timer > timeToBrew)
            {
                state = State.Broken;
                ToggleIsInUse();
                OnStateChanged?.Invoke(this, EventArgs.Empty);
                ToggleCanInteract();
                DialogueManager.Instance.ShowDialogue(coffeOnTheFloorLines);
                ChaosManager.Instance.IncreaseChaosLevel(GetChaosAmount());
            }
        }
    }

    // Methods to check the state of the coffee machine

    public bool IsNormal()
    {
        return state == State.Normal;
    }

    public bool IsInUse()
    {
        return state == State.InUse;
    }

    public bool IsBroken()
    {
        return state == State.Broken;
    }
}
