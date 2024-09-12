using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthView : HealthView
{
    [SerializeField] protected Image HealthImage;

    private void Start()
    {
        HealthImage.fillAmount = Health.MaxHealth;
    }

    protected override void DisplayHealth(float currentHealth)
    {
        if (CurrentCoroutine != null)
        {
            StopCoroutine(CurrentCoroutine);
        }

        float normalizedHealth = currentHealth / Health.MaxHealth;
        CurrentCoroutine = StartCoroutine(DecreaseHealthSmoothy(normalizedHealth));
    }

    private IEnumerator DecreaseHealthSmoothy(float target)
    {
        float elapsedTime = 0f;
        float previousValve = HealthImage.fillAmount;

        while (elapsedTime < SmoothDecreaseDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedPosition = elapsedTime / SmoothDecreaseDuration;
            float intermediateValue = Mathf.Lerp(previousValve, target, normalizedPosition);
            HealthImage.fillAmount = intermediateValue;

            yield return null;
        }

        CurrentCoroutine = null;
    }
}