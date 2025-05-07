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
        TryPickItem(other);
    }

    private void OnTriggerStay(Collider other)
    {
        TryPickItem(other);
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
            _item = null;
        }
    }

    private void TryPickItem(Collider other)
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

    private bool HasNoItem()
        => _item == null;

    private void NotifyNoItem()
        => Debug.Log("Hands are empty, nothing to use");
}