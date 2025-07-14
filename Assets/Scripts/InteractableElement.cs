using UnityEngine;

public abstract class InteractableElement : MonoBehaviour
{
    [SerializeField] private bool canOnlyUseOnce = false;
    private bool hasBeenUsed = false;

    public virtual void Interact()
    {
    }

    private void OnMouseDown()
    {
        if (canOnlyUseOnce && hasBeenUsed)
        {
            return;
        }

        Interact();
        hasBeenUsed = true;
    }
}
