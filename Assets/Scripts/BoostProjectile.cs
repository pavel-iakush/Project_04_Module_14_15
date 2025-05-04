using UnityEngine;

public class BoostProjectile : Boost
{
    public override void Use()
    {
        Vector3 currentPosition = transform.position;
        Quaternion currentRotation = transform.rotation;
        GameObject projectile = Instantiate(gameObject, currentPosition, currentRotation);

        projectile.GetComponent<MoveProjectile>().enabled = true;
        projectile.GetComponent<BoostProjectile>().enabled = false;
        projectile.GetComponent<BoxCollider>().enabled = false;

        Destroy(gameObject);
    }
}
