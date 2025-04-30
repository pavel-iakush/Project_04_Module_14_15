using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private Boost _booster;

    public bool IsEmpty
    {
        get
        {
            if (_booster == null)
                return true;

            if (_booster.gameObject == null)
                return true;

            return false;
        }
    }

    public Vector3 Position => transform.position;

    public void Occupy(Boost booster)
    {
        _booster = booster;
    }
}
