using System.Collections;
using TMPro;
using UnityEngine;

public class TextHealthView : HealthView
{
    [SerializeField] protected TextMeshProUGUI HealthText;

    private void Start()
    {
        HealthText.text = Health.MaxHealth.ToString("");
    }

    protected override void DisplayHealth(float currentHealth)
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

            yield return null;
        }
    }
}