using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Darkness : MonoBehaviour
{
    bool WearOS = true;

    [SerializeField] private float fadeDuration = 1f;

    public MenuB buttons;
    public Image image;
    private Coroutine currentFade;

    private void Awake()
    {
        image.enabled = false;
        Color color = image.color;
        color.a = 0f;
        image.color = color;
    }
    public void FadeIn()
    {
        image.enabled = true;
        StartFade(1f);
    }
    public void FadeOut()
    {
        image.enabled = true;
        image.color = new UnityEngine.Color(0, 0, 0, 1f);
        StartFade(0f);
    }
    private void StartFade(float targetAlpha)
    {
        if (currentFade != null)
            StopCoroutine(currentFade);

        currentFade = StartCoroutine(FadeCoroutine(targetAlpha));
    }
    private IEnumerator FadeCoroutine(float targetAlpha)
    {
        float startAlpha = image.color.a;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;

            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);

            Color color = image.color;
            color.a = alpha;
            image.color = color;

            yield return null;
        }

        Color finalColor = image.color;
        finalColor.a = targetAlpha;
        image.color = finalColor;

        currentFade = null;

        if (buttons.STATE == 1)
        {
            buttons.STATE = 0;
            if (!WearOS)
            {
                SceneManager.LoadScene("Scenes/GameSelect");
            }
            else
            {
                SceneManager.LoadScene("Scenes/WearOS/GameSelect Wear");
            }
        }
        if (buttons.STATE == 2)
        {
            buttons.STATE = 0;
            image.enabled = false;
        }
        if (buttons.STATE == 3)
        {
            buttons.STATE = 0;
            fadeDuration = 1f;
            if (!WearOS)
            {
                SceneManager.LoadScene("Scenes/Game");
            }
            else
            {
                SceneManager.LoadScene("Scenes/WearOS/Game Wear");
            }
        }
        if (buttons.STATE == 4)
        {
            buttons.STATE = 0;
            if (!WearOS)
            {
                SceneManager.LoadScene("Scenes/Menu");
            }
            else
            {
                SceneManager.LoadScene("Scenes/WearOS/Menu Wear");
            }
        }
    }
}