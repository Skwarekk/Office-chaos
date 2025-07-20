using System;
using UnityEngine;

public abstract class InteractableElement : MonoBehaviour
{
    public event EventHandler OnHover;
    public event EventHandler OnUnhover;

    [SerializeField] private int chaosAmount;

    private bool canInteract = true;
    private bool isInUse = false;

    public virtual void Interact()
    {
    }

    private void OnMouseDown()
    {
        if (canInteract && !DialogueManager.Instance.IsDialogueActive())
        {
            Interact();
            float volume = 0.5f;
            SoundManager.Instance.PlayClickSound(volume);
        }
    }

    public void ToggleCanInteract()
    {
        canInteract = !canInteract;
        OnUnhover?.Invoke(this, EventArgs.Empty);
    }

    public void ToggleIsInUse()
    {
        isInUse = !isInUse;
        OnUnhover?.Invoke(this, EventArgs.Empty);
    }

    public int GetChaosAmount()
    {
        return chaosAmount;
    }

    private void OnMouseEnter()
    {
        if (!isInUse && canInteract && !DialogueManager.Instance.IsDialogueActive())
        {
            OnHover?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnMouseExit()
    {
        if (!isInUse && canInteract && !DialogueManager.Instance.IsDialogueActive())
        {
            OnUnhover?.Invoke(this, EventArgs.Empty);
        }
    }
}
