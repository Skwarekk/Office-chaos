using System;
using UnityEngine;

public abstract class InteractableElement : MonoBehaviour
{
    public event EventHandler OnHover;
    public event EventHandler OnUnhover;

    private bool canInteract = true;
    private bool isInUse = false;

    public virtual void Interact()
    {
    }

    private void OnMouseDown()
    {
        if (canInteract)
        {
            Interact();
        }
    }

    public void ToggleCanInteract()
    {
        canInteract = !canInteract;
    }

    public void ToggleIsInUse()
    {
        isInUse = !isInUse;
        OnUnhover?.Invoke(this, EventArgs.Empty);
    }

    private void OnMouseEnter()
    {
        if (!isInUse && canInteract)
        {
            OnHover?.Invoke(this, EventArgs.Empty);
        }
    }

    private void OnMouseExit()
    {
        if (!isInUse && canInteract)
        {
            OnUnhover?.Invoke(this, EventArgs.Empty);
        }
    }
}
