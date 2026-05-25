using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public UnityEngine.UI.Button pause;
    public UnityEngine.UI.Button unpause;
    public Image spr;
    private AudioSource audioSource;
    private void PlaySoundEffect(string soundName)
    {
        AudioClip clip = Resources.Load<AudioClip>(soundName);
        if (clip != null) { audioSource.PlayOneShot(clip); }
        else { Debug.LogError($"Звук не найден по пути: Resources/{soundName}"); }
    }
    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        spr.enabled = false;
    }
    public void On()
    {
        PlaySoundEffect("click");
        unpause.interactable = true;
        pause.interactable = false;
        spr.enabled = true;
    }
    public void Off()
    {
        PlaySoundEffect("click");
        unpause.interactable = false;
        pause.interactable = true;
        spr.enabled = false;
    }
}
