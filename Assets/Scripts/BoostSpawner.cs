using System.Collections.Generic;
using UnityEngine;

public class BoostSpawner : MonoBehaviour
{
    [SerializeField] private List<Boost> _boostPrefab;
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    [SerializeField] private float _cooldown;

    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _cooldown)
        {
            List<SpawnPoint> emptyPoints = GetEmptyPoints();

            if (emptyPoints.Count == 0)
            {
                _time = 0;
                return;
            }

            SpawnPoint spawnPoint = emptyPoints[Random.Range(0, emptyPoints.Count)];

            Boost booster = Instantiate(_boostPrefab[Random.Range(0, _boostPrefab.Count)], spawnPoint.Position, Quaternion.identity);

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
