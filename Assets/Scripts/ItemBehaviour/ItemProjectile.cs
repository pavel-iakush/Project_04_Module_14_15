using UnityEngine;

public class ItemProjectile : Item
{
    public override bool CanUse(GameObject owner)
    {
        throw new System.NotImplementedException();
    }

    public override void Remove()
    {
        throw new System.NotImplementedException();
    }

    public override void Use(GameObject owner)
    {
        throw new System.NotImplementedException();
    }

    /*public override void Use()
    {
        Vector3 currentPosition = transform.position;
        Quaternion currentRotation = transform.rotation;
        GameObject projectile = Instantiate(gameObject, currentPosition, currentRotation);

        projectile.GetComponent<MoveProjectile>().enabled = true;
        projectile.GetComponent<ItemProjectile>().enabled = false;
        projectile.GetComponent<BoxCollider>().enabled = false;

        Destroy(gameObject);
    }*/

}
