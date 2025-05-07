using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private GameObject _owner;
    [SerializeField] private Transform _armSlot;
    [SerializeField] private Transform _projectileSlot;

    private Item _item;

    private KeyCode _useCommand = KeyCode.F;

    private void OnTriggerEnter(Collider other)
    {
        if (_item != null)
            return;

        Item item = other.GetComponent<Item>();

        if (item != null)
        {
            if (item.CanUse(_owner) == false)
            {
                Debug.Log("You are not able to take this item");
                return;
            }

        _item = item;
        _item.transform.SetParent(_armSlot);
        _item.transform.localPosition = Vector3.zero;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(_useCommand))
        {
            if (HasNoItem())
            {
                NotifyNoItem();
                return;
            }

            _item.Use(_owner);
            _item.Remove();
            //play particle effect
            _item = null;
        }
    }

    private bool HasNoItem()
        => _item == null;

    private void NotifyNoItem()
        => Debug.Log("Hands are empty, nothing to use");

    /*private void OnTriggerEnter(Collider other)
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
                _item.Use();
                ClearCurrentBoost();
            }
        }
    }

    private bool IsUseCommandPressed()
        => Input.GetKeyDown(_useCommand);

    private bool HasNoItem()
        => _item == null;

    private void ClearCurrentBoost()
    {
        if (_item != null)
            _item = null;
    }

    private void TryPickBoost(Collider other)
    {
        if (_item != null)
            return;

        _item = other.GetComponent<Item>();

        if (_item.GetComponent<ItemProjectile>())
        {
            AttachToProjectileSlot(_item);
        }
        else
        {
            AttachToArmSlot(_item);
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
        => Debug.Log("Hands are empty, nothing to use");*/
}
