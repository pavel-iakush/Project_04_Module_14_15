using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    private int _value;

    public int Value
    {
        get
        {
            return _value;
        }
        set
        {
            if (_value <= 0)
                _value = 0;

            _value = value;

            if (_value >= 200)
            {
                _value = 200;
                Debug.Log("Maximum health accumulated");
            }
        }
    }

    public void Initialize(int healthPoints)
    {
        _value = healthPoints;
    }
}
