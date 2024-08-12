using UnityEngine;

public class HealthBehaviour : MonoBehaviour
{ 
    virtual public void Die()
    {
        Destroy(gameObject);
    }
}
