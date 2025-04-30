using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpeed : Boost
{
    private float _additiveSpeed = 10.0f;

    private float _speedUpCurrentTime;
    private float _speedUpTime;

    protected override void Update()
    {
        base.Update();

        _speedUpCurrentTime += Time.deltaTime;

        while (_speedUpCurrentTime < _speedUpTime)
            ActivateBoost();


    }

    public override void Use()
    {
        Destroy(gameObject);
        ActivateBoost();

        _speedUpCurrentTime = 0;
    }

    public override void ActivateBoost()
    {
        _mover.MoveSpeed += _additiveSpeed;
    }
}
