using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostProjectile : Boost
{
    public override void UseBoost()
    {
        Vector3 _currentPosition = transform.position;
        Quaternion _currentRotation = transform.rotation;
        GameObject _projectile = Instantiate(gameObject, _currentPosition, _currentRotation);

        _projectile.AddComponent<MoveProjectile>();
        _projectile.GetComponent<BoostProjectile>().enabled = false;
        _projectile.GetComponent<BoxCollider>().enabled = false;

        Destroy(gameObject);
    }
}
