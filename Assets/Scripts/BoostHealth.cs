using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostHealth : Boost
{
    private int _boostHealth = 35;

    public override void UseBoost()
    {
        _healthPoints.Health += _boostHealth;

        Debug.Log($"Player health increased to {_healthPoints.Health}");

        Destroy(gameObject);
    }
}
