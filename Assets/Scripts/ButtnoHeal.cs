using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]

public class ButtnoHeal : MonoBehaviour
{
    [SerializeField] private Health _textHealth;
    [SerializeField] private Health _quickHealth;
    [SerializeField] private Health _smoothHealth;

    private Button _button;

    public float Heal { get; private set; } = 30;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ApplyHealing);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ApplyHealing);
    }

    private void ApplyHealing()
    {
        _textHealth.Heal(Heal);
        _quickHealth.Heal(Heal);
        _smoothHealth.Heal(Heal);
    }
}