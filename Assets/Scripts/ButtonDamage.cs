using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class ButtonDamage : MonoBehaviour
{
    public float Damage { get; private set; } = 30;
    public Button Button { get; private set; }

    private void Awake()
    {
        Button = GetComponent<Button>();
    }
}