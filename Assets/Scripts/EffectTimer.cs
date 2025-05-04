using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTimer : MonoBehaviour
{
    private float _lifetime = 1.0f;
    private float _currentTime;

    private void Update()
    {
        UpdateLifetime();
    }
    private void UpdateLifetime()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _lifetime)
            Destroy(gameObject);
    }
}
