using UnityEngine;
using UnityEngine.UI;

public class GameButton : MonoBehaviour
{
    private AudioSource audioSource;
    public Button bt;
    public MainSc mainscript;
    public int VALUE;
    private void PlaySoundEffect(string soundName)
    {
        AudioClip clip = Resources.Load<AudioClip>(soundName);
        if (clip != null) { audioSource.PlayOneShot(clip); }
        else { Debug.LogError($"Звук не найден по пути: Resources/{soundName}"); }
    }
    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        if (MainSc.fieldX == 7)
        {
            if (VALUE == 1 || VALUE == 9)
            { bt.interactable = false; }
        }
    }
    public void D()
    {
        if (MainSc.canAct)
        {
            PlaySoundEffect("gameClick");
            mainscript.Act(VALUE);
        }
    }
}