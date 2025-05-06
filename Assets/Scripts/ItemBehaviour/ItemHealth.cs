using UnityEngine;

public class ItemHealth : Item
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private Transform _effectSlot;

    private int _boostHealth = 35;

    public override void Use()
    {
        _healthPoints.Value += _boostHealth;
        Debug.Log($"Player health increased to {_healthPoints.Value}");

        Instantiate(_particleSystem, _effectSlot.position, _effectSlot.rotation);

        Destroy(gameObject);
    }
}
