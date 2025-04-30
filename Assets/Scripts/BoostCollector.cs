using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostCollector : MonoBehaviour
{
    [SerializeField] private Transform _armSlot;

    private KeyCode _useCommand = KeyCode.F;

    private List<Boost> _boost;

    private void OnTriggerEnter(Collider other)
    {
        _boost.Add(other.GetComponent<Boost>());

        if (_boost != null)
        {
            _boost[0].transform.parent = _armSlot.transform;
            _boost[0].transform.position = _armSlot.position;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(_useCommand) && _boost != null)
        {
            _boost[0].Use();
            _boost.Clear();
        }
    }
}
