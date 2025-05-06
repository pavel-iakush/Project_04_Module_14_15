using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Transform _armSlot;
    [SerializeField] private Transform _projectileSlot;

    private KeyCode _useCommand = KeyCode.F;
    private Item _currentBoost;

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

        _currentBoost = other.GetComponent<Item>();

        if (_currentBoost.GetComponent<ItemProjectile>())
        {
            AttachToProjectileSlot(_currentBoost);
        }
        else
        {
            AttachToArmSlot(_currentBoost);
        }
    }

    private void AttachToArmSlot(Item item)
    {
        item.transform.parent = _armSlot;
        item.transform.position = _armSlot.position;
    }

    private void AttachToProjectileSlot(Item item)
    {
        item.transform.parent = _projectileSlot;
        item.transform.position = _projectileSlot.position;
        item.transform.localRotation = Quaternion.identity;
    }

    private void NotifyNoItem()
        => Debug.Log("Hands are empty, nothing to use");
}
