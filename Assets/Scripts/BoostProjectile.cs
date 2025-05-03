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
            MoveProjectile();
            UpdateLifetime();
        }
    }

    public override void UseBoost()
    {
        transform.SetParent(null);
        _isShot = true;
    }

    private void MoveProjectile()
    {
        transform.Translate(Vector3.down * _moveSpeed * Time.deltaTime);
    }

    private void UpdateLifetime()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _duration)
            Destroy(gameObject);
    }
}
