using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostProjectile : Boost
{
    private float _moveSpeed = 30.0f;
    private float _duration = 1.0f;
    private float _currentTime;
    private bool _isShot = false;

    protected override void Update()
    {
        if (_isShot)
        {
            transform.Translate(Vector3.down * _moveSpeed * Time.deltaTime);
            _currentTime += Time.deltaTime;

            if (_currentTime >= _duration)
                Destroy(gameObject);
        }
    }

    public override void UseBoost()
    {
        gameObject.transform.parent = null;
        _isShot = true;
    }
}
