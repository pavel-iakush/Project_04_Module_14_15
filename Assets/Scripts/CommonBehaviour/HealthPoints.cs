using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    private int _value;
    private int _maxValue = 200;

    public int Value
    {
        get
        {
            return _value;
        }
        set
        {
            if (value < 0)
            {
                Debug.Log("Negative value not allowed");
                return;
            }

            int newValue = value;

            if (newValue > _maxValue)
                newValue = _maxValue;

            if (newValue == _value)
                return;

            _value = newValue;
            Debug.Log($"Player health changed to {_value}");

            if (_value <= 0)
            {
                Debug.Log("Kind of death happens");
            }
            else if (_value >= _maxValue)
            {
                Debug.Log("Maximum health reached");
            }
        }
    }

    public void Initialize(int healthPoints)
    {
        _value = healthPoints;
    }

    public void AddHealth(int amount)
    {
        Value = _value + amount;
    }
}
