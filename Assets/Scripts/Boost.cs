using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boost : MonoBehaviour
{
    private float _rotateSpeed = 300.0f;
    private float _timeScale = 10.0f;
    private float _yFactor = 500.0f;
    private float _time;

    protected Mover _mover;
    protected HealthPoints _healthPoints;
    public BoostCollector _boostCollector;

    private void Awake()
    {
        _mover = GameObject.Find("Player_grp").GetComponent<Mover>();
        _healthPoints = GameObject.Find("Player_grp").GetComponent<HealthPoints>();
    }

    protected virtual void Update()
    {
        _time += Time.deltaTime;
        transform.Rotate(Vector3.up, _rotateSpeed * Time.deltaTime);
        transform.position += Vector3.up * Mathf.Sin(_time * _timeScale) / _yFactor;
    }

    public abstract void ActivateBoost();

    public virtual void Use()
    {
        Destroy(gameObject);
        ActivateBoost();
    }
}
