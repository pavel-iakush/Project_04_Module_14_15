using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    private int _health;

    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            if (_health <= 0)
                _health = 0;

            _health = value;
        }
    }

    public void Initialize(int healthPoints)
    {
        _health = healthPoints;
    }
}
