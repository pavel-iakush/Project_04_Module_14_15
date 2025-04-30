using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpeed : Boost
{
    private float _additiveSpeed = 10.0f;

    private float _time;
    private float _speedUpTime = 3.0f;

    protected override void Update()
    {
        base.Update();

        _time += Time.deltaTime;

        while (_time < _speedUpTime)
            ActivateBoost();


    }

    public override void Use()
    {
        Destroy(gameObject);
        ActivateBoost();

        _time = 0;
    }

    public override void ActivateBoost()
    {
        _mover.MoveSpeed += _additiveSpeed;
    }
}
