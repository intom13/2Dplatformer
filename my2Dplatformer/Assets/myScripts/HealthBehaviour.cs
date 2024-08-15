using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{ 
    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
