using UnityEngine;

public class Mover : MonoBehaviour
{
    private float _moveSpeed;

    public void Initialize(float speed)
    {
        _moveSpeed = speed;
    }

    public void ProcessMoveTo(Vector3 direction)
        => transform.Translate(direction * _moveSpeed * Time.deltaTime, Space.World);
}
