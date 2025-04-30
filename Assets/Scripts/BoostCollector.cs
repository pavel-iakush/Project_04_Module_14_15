using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostCollector : MonoBehaviour
{
    [SerializeField] private Transform _playerHand;

    private KeyCode _useCommand = KeyCode.F;
    private Boost _boost;

    private bool _isBoostPicked = false;

    private void OnTriggerEnter(Collider other)
    {
        _boost = other.GetComponent<Boost>();

        if (_boost != null && _isBoostPicked == false)
        {
            _boost.transform.parent = _playerHand.transform;

            _isBoostPicked = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(_useCommand) && _boost != null)
        {
            _boost.Use();
            _boost = null;

            _isBoostPicked = false;
        }
    }
}
