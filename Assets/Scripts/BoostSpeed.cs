using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpeed : Boost
{
    [SerializeField] private GameObject _lightning;

    private float _boostSpeed = 10.0f;
    private float _speedUpDuration = 3.0f;
    private float _currentTime;
    private bool _isAccelerated = false;

    protected override void Update()
    {
        base.Update();

        

        if (_isAccelerated == true)
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= _speedUpDuration)
                DeactivateBoost();
        }
    }

    public override void Use()
    {
        ActivateBoost();

        _lightning.SetActive(false);

        _isAccelerated = true;
        _currentTime = 0;
    }

    public override void ActivateBoost()
    {
        _mover.MoveSpeed += _boostSpeed;
    }
    
    private void DeactivateBoost()
    {
        _mover.MoveSpeed -= _boostSpeed;

        _isAccelerated = false;

        Destroy(gameObject);
    }
}
