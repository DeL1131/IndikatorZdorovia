using UnityEngine;
using UnityEngine.UI;

public class QuickHealthView : HealthView
{
    [SerializeField] protected Image HealthImage;

    protected override void DisplayHealth(float currentHealth)
    {
        float normalizedHealth = currentHealth / Health.MaxHealth;
        HealthImage.fillAmount = normalizedHealth;
    }
}