using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostProjectile : Boost
{
    public override void UseBoost()
    {
        Vector3 currentPosition = transform.position;
        Quaternion currentRotation = transform.rotation;
        GameObject projectile = Instantiate(gameObject, currentPosition, currentRotation);

        projectile.AddComponent<MoveProjectile>();
        projectile.GetComponent<BoostProjectile>().enabled = false;
        projectile.GetComponent<BoxCollider>().enabled = false;

        Destroy(gameObject);
    }
}
