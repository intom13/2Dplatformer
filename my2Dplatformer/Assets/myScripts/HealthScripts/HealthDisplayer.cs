using UnityEngine;

public class HealthDisplayer : MonoBehaviour
{
    [SerializeField] protected Character Character;

    private void OnEnable()
    {
        Character.Changed += Display;
    }

    private void OnDisable()
    {
        Character.Changed -= Display;
    }

    protected virtual void Display(float health) { }
}