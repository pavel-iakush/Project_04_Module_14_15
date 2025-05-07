using UnityEngine;

public class ItemHealth : Item
{
    [SerializeField] private int _bonusHealth;
    [SerializeField] private ParticleSystem _healthEffect;

    public override bool CanUse(GameObject owner)
    {
        return owner.GetComponent<HealthPoints>() != null;
    }

    public override void Use(GameObject owner)
    {
        owner.GetComponent<HealthPoints>().AddHealth(_bonusHealth);

        SlotMoveEffect slotMoveEffect = owner.GetComponentInChildren<SlotMoveEffect>();
        ParticleSystem healthEffect = Instantiate(_healthEffect, slotMoveEffect.transform.position, Quaternion.identity, null);
        healthEffect.Play();
        Remove();
    }

    public override void Remove()
    {
        Destroy(gameObject);
    }
}