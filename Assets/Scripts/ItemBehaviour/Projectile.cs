using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 30.0f;
    [SerializeField] private float _lifetime = 1.0f;
    [SerializeField] private ParticleSystem _projectileEffect;

    private float _currentTime;

    private void Start()
    {
        _projectileEffect.Play();
    }

    private void Update()
    {
        ProcessMove();
        UpdateLifetime();
    }

    private void ProcessMove()
        => transform.Translate(Vector3.down * _speed * Time.deltaTime);

    private void UpdateLifetime()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _lifetime)
        {
            _projectileEffect.Stop();
            _projectileEffect.Clear();

            Destroy(gameObject);
        }
    }
}