using UnityEngine;

public class ItemSpeedup : Item
{
    [SerializeField] private GameObject _lightning;
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private Transform _effectSlot;

    private float _boostSpeed = 10.0f;
    private float _speedUpDuration = 3.0f;
    private float _currentTime;
    private bool _isAccelerated = false;

    protected override void Update()
    {
        if (_isAccelerated == true)
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= _speedUpDuration)
                DeactivateBoost();
        }
    }

    public override void Use()
    {
        _mover.MoveSpeed += _boostSpeed;

        _lightning.SetActive(false);

        _isAccelerated = true;
        _currentTime = 0;

        GameObject slot = GameObject.Find("speedEffect_slot");
        _particles.transform.position = slot.transform.position;
        _particles.transform.rotation = slot.transform.rotation;
        _particles.Play();
    }
    
    private void DeactivateBoost()
    {
        _mover.MoveSpeed -= _boostSpeed;

        _isAccelerated = false;

        _particles.Stop();
        _particles.Clear();

        Destroy(gameObject);
    }
}
