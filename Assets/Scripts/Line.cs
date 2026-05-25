using System.Collections;
using UnityEngine;

public class Line : MonoBehaviour
{
    public Transform obj;
    public SpriteRenderer sprite;
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;
    public MenuB buttons;
    public Darkness darkness;
    private AudioSource audioSource;
    private Coroutine currentFade;
    private float fadeDuration = 1f;
    private void PlaySoundEffect(string soundName)
    {
        AudioClip clip = Resources.Load<AudioClip>(soundName);
        if (clip != null) { audioSource.PlayOneShot(clip); }
        else { Debug.LogError($"Звук не найден по пути: Resources/{soundName}"); }
    }
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        sprite.enabled = false;
    }
    public void Show(int x1, int x2, int y1, int y2, int S)
    {
        PlaySoundEffect("line");
        MainSc.canAct = false;
        sprite.enabled = false;
        float x = (x1 + x2) / 2;
        float y = (y1 + y2) / 2;
        float posX = 0;
        float posY = 0;
        if (S == 1)
        {
            sprite.sprite = s1;
            posX = -3.95f + 0.95f * (x + 1.5f);
            posY = -3.95f + 0.95f * (y);
        }
        if (S == 2)
        {
            sprite.sprite = s2;
            posX = -3.95f + 0.95f * (x + 1.5f);
            posY = -3.95f + 0.95f * (y + 0.5f);
        }
        if (S == 3)
        {
            sprite.sprite = s3;
            posX = -3.95f + 0.95f * (x + 1);
            posY = -3.95f + 0.95f * (y + 0.5f);
        }
        if (S == 4)
        {
            sprite.sprite = s4;
            posX = -3.95f + 0.95f * (x + 1.5f);
            posY = -3.95f + 0.95f * (y + 0.5f);
        }
        obj.transform.position = new Vector3(posX, posY, 0);
        StartCoroutine(ShowLine(1f));
    }
    IEnumerator ShowLine(float targetAlpha)
    {
        obj.transform.localScale = new Vector3(10, 10, 10);
        float startAlpha = 0f;
        float time = 0f;
        sprite.enabled = true;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;

            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            float scale = Mathf.Lerp(10, 1, time / fadeDuration);


            Color color = sprite.color;
            color.a = alpha;
            sprite.color = color;
            obj.transform.localScale = new Vector3(scale, scale, 1);

            yield return null;
        }

        Color finalColor = sprite.color;
        finalColor.a = targetAlpha;
        sprite.color = finalColor;

        currentFade = null;

        if (MainSc.scoreRed < MainSc.scoreToWin & MainSc.scoreYellow < MainSc.scoreToWin)
        {
            buttons.STATE = 3;
            darkness.FadeIn();
        }
    }
}
