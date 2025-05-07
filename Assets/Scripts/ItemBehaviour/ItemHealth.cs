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
        SlotMoveEffect slotMoveEffect = owner.GetComponentInChildren<SlotMoveEffect>();

        ParticleSystem healthEffect = Instantiate(_healthEffect, slotMoveEffect.transform.position, Quaternion.identity, null);
        healthEffect.Play();
    }
}
