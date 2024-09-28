using UnityEngine;

public class Player : Character
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out AidKit aidKit))
        {
            ApplyHeal(aidKit.HealValue);

            Destroy(aidKit.gameObject);
        }
    }
}
