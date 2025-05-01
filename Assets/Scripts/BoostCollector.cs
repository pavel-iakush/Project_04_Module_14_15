using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostCollector : MonoBehaviour
{
    [SerializeField] private Transform _armSlot;

    private KeyCode _useCommand = KeyCode.F;

    private List<Boost> _boost = new List<Boost>();

    private void OnTriggerEnter(Collider other)
    {
        Boost currentBoost = other.GetComponent<Boost>();

        if (_boost != null)
        {
            _boost.Add(currentBoost);

            _boost[0].transform.parent = _armSlot.transform;
            _boost[0].transform.position = _armSlot.position;
        }
    }

    private void Update()
    {
        if (IsUseCommandPressed())
        {
            if (_boost.Count == 0)
            {
                Debug.Log("Hands are empty, nothing to use");
            }
            else
            {
                _boost[0].Use();
                _boost.Clear();
            }
        }
    }

    private bool IsUseCommandPressed()
        => Input.GetKeyDown(_useCommand);
}
