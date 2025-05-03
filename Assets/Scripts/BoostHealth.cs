using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostHealth : Boost
{
    [SerializeField] private ParticleSystem _particleSystem;

    private int _boostHealth = 35;

    public override void UseBoost()
    {
        Vector3 currentPosition = transform.position;
        Quaternion currentRotation = transform.rotation;

        _healthPoints.Health += _boostHealth;

        Debug.Log($"Player health increased to {_healthPoints.Health}");

        Instantiate(_particleSystem, currentPosition, currentRotation);
        _particleSystem.transform.rotation = Quaternion.Euler(Vector3.up);
        _particleSystem.Play();
        Destroy(gameObject);
    }
}
