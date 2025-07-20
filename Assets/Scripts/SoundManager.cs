using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    [SerializeField] private AudioClipRefsSO audioClipRefsSO;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("There is more than one Instance of SoundManager!");
        }
        Instance = this;
    }

    private void Start()
    {
        Fan.Instance.OnStateChanged += Fan_OnStateChanged;
        Plant.Instance.OnInteract += Plant_OnInteract;
        ChaosManager.Instance.OnChaosLevelChanged += ChaosManager_OnChaosLevelChanged;
    }

    private void Fan_OnStateChanged(object sender, System.EventArgs e)
    {
        if (Fan.Instance.IsInUse())
        {
            float volume = 0.5f;
            PlaySound(audioClipRefsSO.fanSound, volume);
        }
    }

    private void Plant_OnInteract(object sender, System.EventArgs e)
    {
        float volume = 0.5f;
        PlaySound(audioClipRefsSO.wateringSound, volume);
    }

    private void ChaosManager_OnChaosLevelChanged(object sender, System.EventArgs e)
    {
        float volume = 0.5f;
        PlaySound(audioClipRefsSO.chaosLevelIncreaseSound, volume);
    }

    private void PlaySound(AudioClip audioClip, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, volume);
    }

    private void PlaySound(AudioClip[] audioClipArray, float volume = 1f)
    {
        PlaySound(audioClipArray[Random.Range(0, audioClipArray.Length)], volume);
    }

    public void PlayFootstepSound(float volume)
    {
        PlaySound(audioClipRefsSO.footstepSound, volume);
    }

    public void PlayClickSound(float volume)
    {
        PlaySound(audioClipRefsSO.clickSound, volume);
    }

    public void PlayDialogueSound(float volume)
    {
        PlaySound(audioClipRefsSO.dialogueSound, volume);
    }
}
