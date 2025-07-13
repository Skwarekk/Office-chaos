using UnityEngine;

public class InteractableElement : MonoBehaviour
{
    [SerializeField] private Transform selectedVisual;

    public virtual void Interact()
    {

    }

    private void Awake()
    {
        selectedVisual.gameObject.SetActive(false);
    }

    private void OnMouseEnter()
    {
        selectedVisual.gameObject.SetActive(true);
    }

    private void OnMouseExit()
    {
        selectedVisual.gameObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        Interact();
    }
}
