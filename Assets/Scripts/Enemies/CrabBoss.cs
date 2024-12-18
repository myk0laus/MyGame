using UnityEngine;

public class CrabBoss : PatrolingCrab
{
    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private PatrolingCrab _crabToSpawn;
    [SerializeField] private int _spawnPushPower;
    [SerializeField] private int _maxCrabs;
    private float _spawnDelay;

    private int _spawnedCrabs = 0;

    protected void Update()
    {
        base.Update();
        SpawnCrabs();
    }

    private void SpawnCrabs()
    {
        if(_spawnedCrabs <= _maxCrabs && Time.time - _spawnDelay > 5)
        {
            _spawnDelay = Time.time;
            _spawnedCrabs++;
            Instantiate(_crabToSpawn, _spawnPositions[Random.Range(0, _spawnPositions.Length)].position, Quaternion.identity);
            _crabToSpawn.GetComponent<Rigidbody2D>().AddForce(Vector2.right * _spawnPushPower * Time.deltaTime);
        }
    }
}
