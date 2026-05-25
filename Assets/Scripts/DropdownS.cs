using UnityEngine;
using UnityEngine.UI;

public class DropdownS : MonoBehaviour
{
    private AudioSource audioSource;
    public Dropdown dr;
    public Dropdown dr2;
    private void PlaySoundEffect(string soundName)
    {
        AudioClip clip = Resources.Load<AudioClip>(soundName);
        if (clip != null) { audioSource.PlayOneShot(clip); }
        else { Debug.LogError($"Звук не найден по пути: Resources/{soundName}"); }
    }
    public void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }
    public void Chn()
    {
        PlaySoundEffect("click");
        if (dr.value == 0) { MainSc.fieldX = 9; MainSc.fieldY = 8; }
        if (dr.value == 1) { MainSc.fieldX = 7; MainSc.fieldY = 6; }
        if (dr.value == 2) { MainSc.fieldX = 5; MainSc.fieldY = 5; }
    }
    public void Chn2()
    {
        PlaySoundEffect("click");
        if (dr2.value == 0) { MainSc.scoreToWin = 1; }
        if (dr2.value == 1) { MainSc.scoreToWin = 2; }
        if (dr2.value == 2) { MainSc.scoreToWin = 3; }
        if (dr2.value == 3) { MainSc.scoreToWin = 5; }
    }
}