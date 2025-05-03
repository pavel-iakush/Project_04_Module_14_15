using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class BoostHealth : Boost
{
    [SerializeField] private ParticleSystem _particleSystem;

    private int _boostHealth = 35;

    public override void Use()
    {
        Vector3 currentPosition = transform.position + new Vector3(0, 0.5f, 0);
        Quaternion currentRotation = transform.localRotation;

        _healthPoints.Health += _boostHealth;

        Debug.Log($"Player health increased to {_healthPoints.Health}");

        Instantiate(_particleSystem, currentPosition, currentRotation);
        
        //_particleSystem.Play();

        Destroy(gameObject);
    }
}
