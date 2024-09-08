using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthView : HealthView
{
    [SerializeField] protected Image HealthImage;

    private void Start()
    {
        OriginalColorHealth = HealthImage.color;
        HealthImage.fillAmount = Health.MaxHealth;
    }

    protected override void TakeDamage(float currentHealth)
    {
        float normalizedHealth = currentHealth / Health.MaxHealth;
        StartCoroutine(DecreaseHealthSmoothy(normalizedHealth));
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

            HealthImage.color = Color.Lerp(OriginalColorHealth, DamageHealthColor, ColorBehaviour.Evaluate(normalizedPosition));
            yield return null;
        }
    }
}