using UnityEngine;

public class MenuB : MonoBehaviour
{
    public int STATE = 0;
    public Darkness darkness;
    private AudioSource audioSource;
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
    public void MenuPlay()
    {
        PlaySoundEffect("click");
        STATE = 1;
        darkness.FadeIn();
    }
    public void StartGame()
    {
        PlaySoundEffect("click");
        MainSc.scoreRed = 0;
        MainSc.scoreYellow = 0;
        STATE = 3;
        darkness.FadeIn();
    }
    public void Exit()
    {
        PlaySoundEffect("click");
        STATE = 4;
        darkness.FadeIn();
    }
    public void Shop()
    {
        //soon
    }
    public void Settings()
    {
        //soon
    }
}
