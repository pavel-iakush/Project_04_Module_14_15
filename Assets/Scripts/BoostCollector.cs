using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostCollector : MonoBehaviour
{
    [SerializeField] private Transform _armSlot;
    [SerializeField] private Transform _projectileSlot;

    private KeyCode _useCommand = KeyCode.F;

    private List<Boost> _boost = new List<Boost>();

    private void OnTriggerEnter(Collider other)
    {
        PickBoost(other);
    }

    private void OnTriggerStay(Collider other)
    {
        PickBoost(other);
    }

    private void Update()
    {
        if (IsUseCommandPressed())
        {
            if (HasNoItem())
            {
                Debug.Log("Hands are empty, nothing to use");
            }
            else
            {
                _boost[0].UseBoost();
                _boost.Clear();
            }
        }
    }

    private bool IsUseCommandPressed()
        => Input.GetKeyDown(_useCommand);

    private bool HasNoItem()
        => _boost.Count == 0;

    private void AttachToArmSlot(Boost currentBoost)
    {
        _boost.Add(currentBoost);

        _boost[0].transform.parent = _armSlot.transform;
        _boost[0].transform.position = _armSlot.position;
    }

    private void AttachToProjectileSlot(Boost currentBoost)
    {
        _boost.Add(currentBoost);

        _boost[0].transform.parent = _projectileSlot.transform;
        _boost[0].transform.position = _projectileSlot.position;
        _boost[0].transform.localRotation = Quaternion.identity;
    }

    private void PickBoost(Collider other)
    {
        Boost currentBoost = other.GetComponent<Boost>();

        if (_boost != null)
        {
            AttachToArmSlot(currentBoost);
        }

        if (_boost != null && currentBoost.GetComponent<BoostProjectile>())
        {
            AttachToProjectileSlot(currentBoost);
        }
    }
}
