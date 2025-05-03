using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    private float _moveSpeed = 30.0f;
    private float _lifetime = 1.0f;
    private float _currentTime;

    private void Update()
    {
        ProcessMove();
        UpdateLifetime();
    }

    private void ProcessMove()
    {
        transform.Translate(Vector3.down * _moveSpeed * Time.deltaTime);
    }

    private void UpdateLifetime()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _lifetime)
            Destroy(gameObject);
    }
}
