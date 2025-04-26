using System.Collections.Generic;
using UnityEngine;

public class BoostSpawner : MonoBehaviour
{
    [SerializeField] private List<Booster> _boostPrefab;
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    [SerializeField] private float _cooldown;

    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _cooldown )
        {
            List<SpawnPoint> emptyPoints = GetEmptyPoints();

            if (emptyPoints.Count == 0)
            {
                this._time = 0;
                return;
            }

            SpawnPoint spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
            Booster boostPrefab = _boostPrefab[Random.Range(0, _boostPrefab.Count)];

            Booster booster = Instantiate(boostPrefab, spawnPoint.Position, Quaternion.identity);

            spawnPoint.Occupy(booster);

            _time = 0;
        }
    }

    private List<SpawnPoint> GetEmptyPoints()
    {
        List<SpawnPoint> emptyPoints = new List<SpawnPoint>();

        foreach (SpawnPoint point in _spawnPoints)
        {
            if (point.IsEmpty)
                emptyPoints.Add(point);
        }

        return emptyPoints;
    }
}
