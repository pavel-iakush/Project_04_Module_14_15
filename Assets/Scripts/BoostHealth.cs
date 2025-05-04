using UnityEngine;

public class BoostHealth : Boost
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Transform _effectSlot;

    private int _boostHealth = 35;

    public override void Use()
    {
        _healthPoints.Health += _boostHealth;
        Debug.Log($"Player health increased to {_healthPoints.Health}");

        Instantiate(_particleSystem, _effectSlot.position, _effectSlot.rotation);

        Destroy(gameObject);
    }
}
