using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager: MonoBehaviour
{
    public event EventHandler<OnNewDialogueLineEventArgs> OnNewDialogueLine;
    public class OnNewDialogueLineEventArgs : EventArgs
    {
        public string line;
    }

    public event EventHandler OnDialogueEnded;

    public static DialogueManager Instance { get; private set; }

    [SerializeField] private string[] startDialogueLines;

    private Queue<string> dialogueLines;
    private bool isDialogueActive = false;
    private bool isTyping = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one instance of DialogueManager!");
        }
        Instance = this;
    }

    private void Start()
    {
        dialogueLines = new Queue<string>();
        GameInput.Instance.OnNextDialogue += Instance_OnNextDialogue;

        ShowDialogue(startDialogueLines);
    }

    private void Instance_OnNextDialogue(object sender, EventArgs e)
    {
        if (!isTyping)
        {
            NextDialogue();
        }
    }

    public void ShowDialogue(string[] textLines)
    {
        foreach (var line in textLines)
        {
            dialogueLines.Enqueue(line);
        }

        if (!isDialogueActive)
        {
            NextDialogue();
        }
    }

    private void NextDialogue()
    {
        GameManager.Instance.StartDialogue();
        isDialogueActive = true;
        if (dialogueLines.Count > 0)
        {
            string line = dialogueLines.Dequeue();
            OnNewDialogueLine?.Invoke(this, new OnNewDialogueLineEventArgs { line = line });
        }
        else
        {
            OnDialogueEnded?.Invoke(this, EventArgs.Empty);
            GameManager.Instance.EndDialogue();
            dialogueLines.Clear();
            isDialogueActive = false;
        }
    }

    public void ToggleIsTyping()
    {
        isTyping = !isTyping;
    }

    public bool IsDialogueActive()
    {
        return isDialogueActive;
    }
}
