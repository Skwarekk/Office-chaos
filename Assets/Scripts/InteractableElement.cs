using System;
using UnityEngine;

public abstract class InteractableElement : MonoBehaviour
{
    public event EventHandler OnHover;
    public event EventHandler OnUnhover;

    [SerializeField] private string[] textLines;

    private bool canInteract = true;

    public virtual void Interact()
    {
    }

    public virtual void CannotInteract()
    {
        
    }

    private void OnMouseDown()
    {
        if (canInteract)
        {
            Interact();
        }
        else
        {
            CannotInteract();
        }
    }

    public void ToggleCanInteract()
    {
        canInteract = !canInteract;
    }

    private void OnMouseEnter()
    {
        OnHover?.Invoke(this, EventArgs.Empty);
    }

    private void OnMouseExit()
    {
        OnUnhover?.Invoke(this, EventArgs.Empty);
    }
}
