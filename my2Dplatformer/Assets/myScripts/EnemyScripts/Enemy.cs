using System;
using UnityEngine;

public class Enemy : Health
{
    protected override void Die()
    {
        Destroy(gameObject);
    }
}
