using UnityEngine;

public class SelectedElementVisual : MonoBehaviour
{
    [SerializeField] private GameObject[] visualGameObjectArray;
    [SerializeField] private InteractableElement interactableElement;

    private void Start()
    {
        interactableElement.OnHover += InteractableElement_OnHover;
        interactableElement.OnUnhover += InteractableElement_OnUnhover;
    }

    private void InteractableElement_OnHover(object sender, System.EventArgs e)
    {
        Show();
    }

    private void InteractableElement_OnUnhover(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void Show()
    {
        foreach (GameObject visualGameObject in visualGameObjectArray)
        {
            visualGameObject.SetActive(true);
        }
    }

    private void Hide()
    {
        foreach (GameObject visualGameObject in visualGameObjectArray)
        {
            visualGameObject.SetActive(false);
        }
    }
}
