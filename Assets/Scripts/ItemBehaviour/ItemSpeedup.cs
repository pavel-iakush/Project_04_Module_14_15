using UnityEngine;

public class ItemSpeedup : Item
{
    [SerializeField] private float _bonusSpeed;
    [SerializeField] private float _speedupDuration;

    [SerializeField] private GameObject _lightning;
    [SerializeField] private ParticleSystem _speedupEffect;

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

            if (_time >= _speedupDuration)
                Remove();
        }
    }

    public override void Remove()
    {
        _owner.GetComponent<Mover>().DecreaseSpeed(_bonusSpeed);

        _speedupEffect.Stop();
        _speedupEffect.Clear();

        Destroy(gameObject);
    }
}