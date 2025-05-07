using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ItemSpeedup : Item
{
    [SerializeField] private float _bonusSpeed;
    [SerializeField] private GameObject _lightning;
    [SerializeField] private ParticleSystem _speedupEffect;

    private float _speedUpDuration = 3.0f;
    private float _time;
    private bool _isAccelerated = false;

    private GameObject _owner;

    public override bool CanUse(GameObject owner)
    {
        return owner.GetComponent<Mover>() != null;
    }

    public override void Use(GameObject owner)
    {
        _owner = owner;

        owner.GetComponent<Mover>().IncreaseSpeed(_bonusSpeed);

        _lightning.SetActive(false);
        _isAccelerated = true;
        _time = 0.0f;

        SlotMoveEffect slotMoveEffect = owner.GetComponentInChildren<SlotMoveEffect>();
        _speedupEffect.transform.position = slotMoveEffect.transform.position;
        _speedupEffect.transform.rotation = slotMoveEffect.transform.rotation;
        _speedupEffect.Play();
    }

    private void Update()
    {
        if (_isAccelerated)
        {
            _time += Time.deltaTime;

            if (_time >= _speedUpDuration)
                Remove();
        }
    }

    public override void Remove()
    {
        _owner.GetComponent<Mover>().DecreaseSpeed(_bonusSpeed);
        _isAccelerated = false;

        _speedupEffect.Stop();
        _speedupEffect.Clear();

        Debug.Log("control point");

        Destroy(gameObject);
    }
    /*[SerializeField] private GameObject _lightning;
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
        _mover.Value += _boostSpeed;

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
        _mover.Value -= _boostSpeed;

        _isAccelerated = false;

        _particles.Stop();
        _particles.Clear();

        Destroy(gameObject);
    }*/

}
