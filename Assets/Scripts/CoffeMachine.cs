using UnityEngine;

public class CoffeMachine : InteractableElement
{
    public override void Interact()
    {
        base.Interact();
        Debug.Log("CoffeMachine Interacted");
    }
}
