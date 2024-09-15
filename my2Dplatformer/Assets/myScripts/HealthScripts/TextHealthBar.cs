using TMPro;
using UnityEngine;

public class TextHealthBar : HealthDisplayer
{
    [SerializeField] private TMP_Text _bar;

    private readonly char _textBarSeparator = '/';

    protected override void Display(float health)
    {
        _bar.text = health.ToString() + _textBarSeparator + Character.MaxHealth;
    }
}
