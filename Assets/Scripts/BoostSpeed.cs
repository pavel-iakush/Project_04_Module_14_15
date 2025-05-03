using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSpeed : Boost
{
    [SerializeField] private GameObject _lightning;
    [SerializeField] private ParticleSystem _particles;

    private float _boostSpeed = 10.0f;
    private float _speedUpDuration = 3.0f;
    private float _currentTime;
    private bool _isAccelerated = false;

    protected override void Update()
    {
        if (_isAccelerated == true)
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= _speedUpDuration)
                DeactivateBoost();
        }
    }

    public override void Use()
    {
        _mover.MoveSpeed += _boostSpeed;

        _lightning.SetActive(false);

        _isAccelerated = true;
        _currentTime = 0;

        _particles.transform.rotation = Quaternion.Euler(-45, 0, 0);
        _particles.Play();
    }
    
    private void DeactivateBoost()
    {
        _mover.MoveSpeed -= _boostSpeed;

        _isAccelerated = false;

        _particles.Stop();
        _particles.Clear();

        Destroy(gameObject);
    }
}
