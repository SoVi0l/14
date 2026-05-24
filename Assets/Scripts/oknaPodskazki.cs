using UnityEngine;
using System.Collections;

public class VRStaticTooltip : MonoBehaviour
{
    [Header("Настройки")]
    public CanvasGroup tooltipCanvasGroup;
    public float waitTime = 3f;
    public float fadeSpeed = 1f;

    private bool _isUsed = false;

    void Start()
    {
        if (tooltipCanvasGroup != null) tooltipCanvasGroup.alpha = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_isUsed && other.CompareTag("Player"))
        {
            _isUsed = true;
            Debug.Log("Игрок подошел к статичному объекту!");
            StartCoroutine(ShowSequence());
        }
    }

    IEnumerator ShowSequence()
    {
        float t = 0;
        while (t < fadeSpeed)
        {
            t += Time.deltaTime;
            tooltipCanvasGroup.alpha = t / fadeSpeed;
            yield return null;
        }
        tooltipCanvasGroup.alpha = 1;

        yield return new WaitForSeconds(waitTime);

        t = 0;
        while (t < fadeSpeed)
        {
            t += Time.deltaTime;
            tooltipCanvasGroup.alpha = 1 - (t / fadeSpeed);
            yield return null;
        }
        tooltipCanvasGroup.alpha = 0;
    }
}