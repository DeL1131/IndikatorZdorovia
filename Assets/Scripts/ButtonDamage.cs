using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ButtonDamage : MonoBehaviour
{
    [SerializeField] private Health _textHealth;
    [SerializeField] private Health _quickHealth;
    [SerializeField] private Health _smoothHealth;

    private Button _button;

    public float Damage { get; private set; } = 30;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ApplyDamage);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ApplyDamage);
    }

    private void ApplyDamage()
    {
        _textHealth.TakeDamage(Damage);
        _quickHealth.TakeDamage(Damage);
        _smoothHealth.TakeDamage(Damage);
    }
}