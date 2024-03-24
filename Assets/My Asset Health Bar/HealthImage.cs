using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class HealthImage : HealthDisplay
{
    private const float FillDuration = 0.5f;

    [SerializeField] private Image _imageHealt;

    private Coroutine _smoothFillCoroutine;

    protected override void HandleHealthChanged(float currentHealth, float maxHealth)
    {
        float targetFillAmount = currentHealth / maxHealth;

        if (_smoothFillCoroutine != null)
        {
            StopCoroutine(_smoothFillCoroutine);
        }

        _smoothFillCoroutine = StartCoroutine(SmoothFill(targetFillAmount));
    }

    private IEnumerator SmoothFill(float targetFillAmount)
    {
        float startFillAmount = _imageHealt.fillAmount;
        float elapsedTime = 0f;

        while (elapsedTime < FillDuration)
        {
            elapsedTime += Time.deltaTime;
            _imageHealt.fillAmount = Mathf.Lerp(startFillAmount, targetFillAmount, elapsedTime / FillDuration);
            yield return null;
        }

        _imageHealt.fillAmount = targetFillAmount;
    }
}
