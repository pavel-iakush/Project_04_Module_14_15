using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostCollector : MonoBehaviour
{
    [SerializeField] private Transform _armSlot;
    [SerializeField] private Transform _projectileSlot;

    private KeyCode _useCommand = KeyCode.F;
    private Boost _currentBoost;

    private void OnTriggerEnter(Collider other)
        => TryPickBoost(other);

    private void OnTriggerStay(Collider other)
        => TryPickBoost(other);

    private void Update()
    {
        if (IsUseCommandPressed())
        {
            if (HasNoItem())
            {
                NotifyNoItem();
            }
            else
            {
                _currentBoost.Use();
                ClearCurrentBoost();
            }
        }
    }

    private bool IsUseCommandPressed()
        => Input.GetKeyDown(_useCommand);

    private bool HasNoItem()
        => _currentBoost == null;

    private void ClearCurrentBoost()
    {
        if (_currentBoost != null)
            _currentBoost = null;
    }

    private void TryPickBoost(Collider other)
    {
        if (_currentBoost != null)
            return;

        _currentBoost = other.GetComponent<Boost>();

        if (_currentBoost.GetComponent<BoostProjectile>())
        {
            AttachToProjectileSlot(_currentBoost);
        }
        else
        {
            AttachToArmSlot(_currentBoost);
        }
    }

    private void AttachToArmSlot(Boost boost)
    {
        boost.transform.parent = _armSlot;
        boost.transform.position = _armSlot.position;
    }

    private void AttachToProjectileSlot(Boost boost)
    {
        boost.transform.parent = _projectileSlot;
        boost.transform.position = _projectileSlot.position;
        boost.transform.localRotation = Quaternion.identity;
    }

    private void NotifyNoItem()
        => Debug.Log("Hands are empty, nothing to use");
}
