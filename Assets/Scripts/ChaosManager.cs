using System;
using UnityEngine;

public class ChaosManager : MonoBehaviour
{
    public event EventHandler OnChaosLevelChanged;

    public static ChaosManager Instance { get; private set; }

    [SerializeField][Range(min: 0, max: 100)] private int chaosLevel;

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
        DialogueManager.Instance.ShowDialogue(new string[] {$"Chaos level increased to {chaosLevel}!"});
        OnChaosLevelChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetChaosLevel()
    {
        return chaosLevel;
    }
}
