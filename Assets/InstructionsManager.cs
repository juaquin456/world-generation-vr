using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasDisabler : MonoBehaviour
{
    // Reference to the CanvasGroup
    private CanvasGroup canvasGroup;

    void Start()
    {
        // Get the CanvasGroup component
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup != null)
        {
            // Start the coroutine to fade out and disable the Canvas
            StartCoroutine(FadeOutCanvas(3f));
        }
        else
        {
            Debug.LogError("CanvasGroup component not found!");
        }
    }

    private IEnumerator FadeOutCanvas(float duration)
    {

        yield return new WaitForSeconds(duration);

        float startAlpha = canvasGroup.alpha;
        float rate = 1.0f / duration;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0, progress);
            progress += rate * Time.deltaTime;

            yield return null;
        }

        canvasGroup.alpha = 0;
        canvasGroup.gameObject.SetActive(false);
    }
}
