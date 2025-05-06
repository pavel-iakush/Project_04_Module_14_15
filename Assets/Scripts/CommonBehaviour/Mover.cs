using UnityEngine;

public class Mover : MonoBehaviour
{
    private float _moveSpeed;

    public float MoveSpeed
    {   
        get
        {
            return _moveSpeed;
        }
        set
        {
            _moveSpeed = value;
        }
    }

    public void Initialize(float speed)
    {
        _moveSpeed = speed;
    }

    public void ProcessMoveTo(Vector3 direction)
        => transform.Translate(direction * _moveSpeed * Time.deltaTime, Space.World);
}
