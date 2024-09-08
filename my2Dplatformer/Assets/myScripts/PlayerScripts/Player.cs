using System;
using UnityEngine;

public class Player : Health
{
    public event Action GameFinished;

    protected override void Die()
    {
        GameFinished?.Invoke();
    }
}
