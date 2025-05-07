using UnityEngine;

public class ItemProjectile : Item
{
    [SerializeField] private Projectile _projectilePrefab;

    public override bool CanUse(GameObject owner)
    {
        return owner.GetComponentInChildren<SlotProjectile>() != null;
    }

    public override void Use(GameObject owner)
    {
        SlotProjectile slotProjectile = owner.GetComponentInChildren<SlotProjectile>();
        Projectile projectile = Instantiate(_projectilePrefab, slotProjectile.transform.position, Quaternion.identity, null);

        projectile.GetComponent<Projectile>().enabled = true;
        projectile.GetComponent<ItemProjectile>().enabled = false;
        projectile.GetComponent<BoxCollider>().enabled = false;

        Remove();
    }

    public override void Remove()
    {
        Destroy(gameObject);
    }
}