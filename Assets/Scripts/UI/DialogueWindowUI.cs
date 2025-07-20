using TMPro;
using UnityEngine;

public class DialogueWindowUI: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private float letterDelay = 0.1f;
    private float timer;
    private bool isTyping = false;
    private string currentLine;
    private int currentLineIndex;

    private void Start()
    {
        DialogueManager.Instance.OnNewDialogueLine += Instance_OnNewDialogueLine;
        DialogueManager.Instance.OnDialogueEnded += Instance_OnDialogueEnded;
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;

        Hide();
    }

    private void GameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (GameManager.Instance.IsGameOver())
        {
            Hide();
        }
    }

    private void Instance_OnNewDialogueLine(object sender, DialogueManager.OnNewDialogueLineEventArgs e)
    {
        if (!isTyping)
        {
            Show();
            dialogueText.text = string.Empty;
            ShowDialogueLine(e.line);
        }
    }

    private void Instance_OnDialogueEnded(object sender, System.EventArgs e)
    {
        if (!isTyping)
        {
            Hide();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void ShowDialogueLine(string line)
    {
        currentLine = line;
        isTyping = true;
        currentLineIndex = 0;
        DialogueManager.Instance.ToggleIsTyping();
    }

    private void Update()
    {
        if (isTyping)
        {
            timer += Time.deltaTime;
            if (timer > letterDelay)
            {
                timer = 0f;
                if (currentLine.Length > dialogueText.text.Length)
                {
                    dialogueText.text += currentLine[currentLineIndex];
                    currentLineIndex++;

                    float volume = 0.5f;
                    SoundManager.Instance.PlayDialogueSound(volume);
                }
                else
                {
                    isTyping = false;
                    DialogueManager.Instance.ToggleIsTyping();
                }
            }
        }
    }
}
