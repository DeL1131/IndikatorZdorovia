using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Health))]

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected float SmoothDecreaseDuration = 0.5f;
    [SerializeField] protected Health Health; 
    [SerializeField] protected Color DamageHealthColor;
    [SerializeField] protected AnimationCurve ColorBehaviour;

    protected Image Image;

    protected readonly int HeartAnimationTrigger = Animator.StringToHash("HeartAnimation");

    protected Color OriginalColorHealth;

    private void OnEnable()
    {
        Health.Changed += TakeDamage;
    }

    private void OnDisable()
    {
        Health.Changed -= TakeDamage;
    }

    protected virtual void TakeDamage(float damage) { }
}