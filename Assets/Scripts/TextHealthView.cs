using System.Collections;
using TMPro;
using UnityEngine;

public class TextHealthView : HealthView
{
    [SerializeField] protected TextMeshProUGUI HealthText;

    private void Start()
    {
        OriginalColorHealth = HealthText.color;
        HealthText.text = Health.MaxHealth.ToString("");
    }

    protected override void TakeDamage(float currentHealth)
    {
        StartCoroutine(DecreaseHealthSmoothy(currentHealth));
    }

    private IEnumerator DecreaseHealthSmoothy(float target)
    {
        float elapsedTime = 0f;
        float previousValve = float.Parse(HealthText.text);

        while (elapsedTime < SmoothDecreaseDuration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedPosition = elapsedTime / SmoothDecreaseDuration;
            float intermediateValue = Mathf.Lerp(previousValve, target, normalizedPosition);
            HealthText.text = intermediateValue.ToString("");

            HealthText.color = Color.Lerp(OriginalColorHealth, DamageHealthColor, ColorBehaviour.Evaluate(normalizedPosition));
            yield return null;
        }
    }
}