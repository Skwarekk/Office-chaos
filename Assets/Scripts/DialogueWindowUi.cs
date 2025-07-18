using TMPro;
using UnityEngine;

public class DialogueWindowUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;

    private void Start()
    {
        DialogueManager.Instance.OnNewDialogueLine += Instance_OnNewDialogueLine;
        DialogueManager.Instance.OnDialogueEnded += Instance_OnDialogueEnded;

        Hide();
    }

    private void Instance_OnNewDialogueLine(object sender, DialogueManager.OnNewDialogueLineEventArgs e)
    {
        Show();
        dialogueText.text = e.line;
    }

    private void Instance_OnDialogueEnded(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
