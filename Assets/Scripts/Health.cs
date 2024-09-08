using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    [SerializeField] protected ButtonDamage ButtonDamage;
    [SerializeField] protected ButtnoHeal ButtonHeal;

    private float _currentHealth;

    public event Action<float> Changed;

    public float MaxHealth => _maxHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
        ButtonDamage.Button.onClick.AddListener(() => TakeDamage(ButtonDamage.Damage));
        ButtonHeal.Button.onClick.AddListener(() => Heal(ButtonHeal.Heal));     
    }

    private void OnDisable()
    {
        ButtonDamage.Button.onClick.RemoveListener(() => TakeDamage(ButtonDamage.Damage));
        ButtonHeal.Button.onClick.RemoveListener(() => Heal(ButtonHeal.Heal));
    }

    public void TakeDamage(float damage)
    {       
        _currentHealth = Mathf.Clamp(_currentHealth - damage, 0, _maxHealth);
        Changed?.Invoke(_currentHealth);               
    }

    public void Heal(float healAmount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + healAmount, 0, _maxHealth);
        Changed?.Invoke(_currentHealth);
    }
}