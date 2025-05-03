using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Boost : MonoBehaviour
{
    private string _playerName = "Player_grp";

    protected Mover _mover;
    protected HealthPoints _healthPoints;

    private void Awake()
    {
        _mover = GameObject.Find(_playerName).GetComponent<Mover>();
        _healthPoints = GameObject.Find(_playerName).GetComponent<HealthPoints>();
    }

    protected virtual void Update()
    {
        
    }

    public abstract void Use();

}
