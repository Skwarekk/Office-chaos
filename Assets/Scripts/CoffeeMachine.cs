using System;
using UnityEngine;

public class CoffeeMachine : InteractableElement
{
    [Serializable]
    public struct CoffeeMachineDialogue
    {
        public string[] coffeOnTheFloorLines;
        public string[] coffeeMachineBrokenLines;
    }

    public event EventHandler OnStateChanged;

    private enum State
    {
        Normal,
        InUse,
        Broken
    }

    [SerializeField] private CoffeeMachineDialogue dialogue;
    [Space]
    [SerializeField] private float timeToBrew = 1.5f;
    private float timer;

    private State state;

    public override void Interact()
    {
        state = State.InUse;
        OnStateChanged?.Invoke(this, EventArgs.Empty);
    }

    public override void CannotInteract()
    {
        DialogueSystem.ShowDialogue(dialogue.coffeeMachineBrokenLines);
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
                OnStateChanged?.Invoke(this, EventArgs.Empty);
                ToggleCanInteract();
                DialogueSystem.ShowDialogue(dialogue.coffeOnTheFloorLines);
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
