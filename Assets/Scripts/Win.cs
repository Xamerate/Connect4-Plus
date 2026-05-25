using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public Image sprite;
    public Image but1;
    public Image but2;
    public Sprite yellow;
    public Sprite red;
    private float fadeDuration = 1f;
    void Start()
    {
        sprite.enabled = false;
        but1.enabled = false;
        but2.enabled = false;
    }
    public void G(int g)
    {
        if (g == 1) { MainSc.scoreYellow++; }
        else { MainSc.scoreRed++; }

        if (MainSc.scoreRed >= MainSc.scoreToWin)
        {
            sprite.sprite = red;
            StartCoroutine(ShowLine(1.0f));
        }
        if (MainSc.scoreYellow >= MainSc.scoreToWin)
        {
            sprite.sprite = yellow;
            StartCoroutine(ShowLine(1.0f));
        }
    }
    IEnumerator ShowLine(float targetAlpha)
    {
        float startAlpha = 0f;
        float time = 0f;
        sprite.enabled = true;
        but1.enabled = true;
        but2.enabled = true;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;

            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            float scale = Mathf.Lerp(10, 1, time / fadeDuration);


            Color color = sprite.color;
            color.a = alpha;
            sprite.color = color;
            but1.color = color;
            but2.color = color;
            yield return null;
        }

        Color finalColor = sprite.color;
        finalColor.a = targetAlpha;
        sprite.color = finalColor;
    }
}
