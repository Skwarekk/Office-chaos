using UnityEngine;

public abstract class InteractableElement : MonoBehaviour
{
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
}
