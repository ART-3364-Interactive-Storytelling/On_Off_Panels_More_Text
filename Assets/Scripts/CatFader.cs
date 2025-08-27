using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CatFader : MonoBehaviour
{
    public Image catImage; // Assign your cat's UI Image in the Inspector

    void Start()
    {
        if (catImage != null)
        {
            var color = catImage.color;
            color.a = 0f;
            catImage.color = color;
            StartCoroutine(FadeCat());
        }
    }

    IEnumerator FadeCat()
    {
        while (true)
        {
            // Fade in
            yield return StartCoroutine(FadeTo(1f, 5f));
            // Stay visible
            yield return new WaitForSeconds(5f);
            // Fade out
            yield return StartCoroutine(FadeTo(0f, 5f));
            // Stay invisible
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator FadeTo(float targetAlpha, float duration)
    {
        float startAlpha = catImage.color.a;
        float time = 0f;
        while (time < duration)
        {
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            var color = catImage.color;
            color.a = alpha;
            catImage.color = color;
            time += Time.deltaTime;
            yield return null;
        }
        var finalColor = catImage.color;
        finalColor.a = targetAlpha;
        catImage.color = finalColor;
    }
}
