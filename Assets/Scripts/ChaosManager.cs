using System;
using UnityEngine;

public class ChaosManager : MonoBehaviour
{
    public event EventHandler OnChaosLevelChanged;
    public event EventHandler OnChaosLevelMaxed;

    public static ChaosManager Instance { get; private set; }

    [SerializeField] private string[] maxChaosLevelLines;

    private int chaosLevel;
    private int maxChaosLevel = 100;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one instance of ChaosManager!");
        }
        Instance = this;
    }

    public void IncreaseChaosLevel(int value)
    {
        chaosLevel += value;
        DialogueManager.Instance.ShowDialogue(new string[] {$"CHAOS LEVEL HAVE INCREASED TO {chaosLevel}!"});
        OnChaosLevelChanged?.Invoke(this, EventArgs.Empty);

        if(chaosLevel >= maxChaosLevel)
        {
            DialogueManager.Instance.ShowDialogue(maxChaosLevelLines);
            OnChaosLevelMaxed?.Invoke(this, EventArgs.Empty);
        }
    }

    public int GetChaosLevel()
    {
        return chaosLevel;
    }
}
