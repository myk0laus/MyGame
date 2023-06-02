using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabBoss : PatrolingCrab
{
    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private CrabChildOfBoss _crabToSpawn;
    [SerializeField] private int _spawnPushPower;
    [SerializeField] private int _maxCrabs;
    private float _spawnDelay;

    private void Update()
    {
        base.Update();
        SpawnCrabs();
    }

    private void SpawnCrabs()
    {
        if(CrabChildOfBoss.countOfCrabs <= _maxCrabs && Time.time - _spawnDelay > 10)
        {
            _spawnDelay = Time.time;
            Instantiate(_crabToSpawn, _spawnPositions[Random.Range(0, _spawnPositions.Length)].position, Quaternion.identity);
            _crabToSpawn.GetComponent<Rigidbody2D>().AddForce(Vector2.right * _spawnPushPower * Time.deltaTime);
        }
    }
}
