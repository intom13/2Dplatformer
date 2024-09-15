using UnityEngine;
using UnityEngine.UI;

public class HealthBar : HealthDisplayer
{
    [SerializeField] private Slider _bar;

    protected override void Display(float health)
    {
        _bar.value = health / Character.MaxHealth;
    }
}
