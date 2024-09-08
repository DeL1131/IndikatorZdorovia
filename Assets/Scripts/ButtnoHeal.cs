using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Button))]

public class ButtnoHeal : MonoBehaviour
{
    public float Heal { get; private set; } = 30;
    public Button Button { get; private set; }

    private void Awake()
    {
       Button = GetComponent<Button>(); 
    }
}