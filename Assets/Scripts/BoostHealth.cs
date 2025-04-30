using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostHealth : Boost
{
    private int _boostHealth = 35;

    public override void ActivateBoost()
    {
        _healthPoints.Health += _boostHealth;

        Debug.Log($"Player health {_healthPoints.Health}");
    }
}
