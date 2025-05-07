using UnityEngine;

public class FloatingAnimation : MonoBehaviour
{
    private float _rotateSpeed;
    private float _timeScale;
    private float _yFactor = 500.0f;
    private float _time;

    private void Awake()
    {
        _rotateSpeed = Random.Range(200.0f, 360.0f);
        _timeScale = Random.Range(8.0f, 14.0f);
    }

    private void Update()
    {
        _time += Time.deltaTime;
        transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
        transform.position += Vector3.up * Mathf.Sin(_time * _timeScale) / _yFactor;
    }
}