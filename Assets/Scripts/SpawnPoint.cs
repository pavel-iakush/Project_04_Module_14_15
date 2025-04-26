using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private Booster _booster;

    public bool IsEmpty
    {
        get
        {
            if (_booster == null)
                return true;

            if (_booster.gameObject == null)
                return false;

            return false;
        }
    }

    public Vector3 Position => transform.position;

    public void Occupy(Booster booster)
    {
        _booster = booster;
    }
}
