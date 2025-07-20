using System;
using UnityEngine;

public class Papers : InteractableElement
{
    public event EventHandler OnInteract;

    [SerializeField] private string[] papersOnTheFloorLines;

    public override void Interact()
    {
        OnInteract?.Invoke(this, EventArgs.Empty);
        ToggleCanInteract();
        DialogueManager.Instance.ShowDialogue(papersOnTheFloorLines);
        ChaosManager.Instance.IncreaseChaosLevel(GetChaosAmount());
    }
}
