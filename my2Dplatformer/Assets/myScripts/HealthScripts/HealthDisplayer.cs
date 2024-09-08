using UnityEngine;

public class HealthDisplayer : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable()
    {
        Health.Changed += Display;
    }

    private void OnDisable()
    {
        Health.Changed -= Display;
    }

    protected virtual void Display(float health) { }
}