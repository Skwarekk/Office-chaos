using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public static void ShowDialogue(string line)
    {
        Debug.Log(line);
    }

    public static void ShowDialogue(string[] textLines)
    {
        foreach (var line in textLines)
        {
            ShowDialogue(line);
        }
    }
}
