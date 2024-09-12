using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Health))]

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected float SmoothDecreaseDuration = 0.5f;
    [SerializeField] protected Health Health;
    protected Coroutine CurrentCoroutine;

    protected Image Image;

    private void OnEnable()
    {
        Health.Changed += DisplayHealth;
    }

    private void OnDisable()
    {
        Health.Changed -= DisplayHealth;
    }

    protected abstract void DisplayHealth(float damage);
}