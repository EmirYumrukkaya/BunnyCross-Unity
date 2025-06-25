using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    [SerializeField] GameObject _car;
    int _spwLocation;
    bool _spawnAble = true;

    public int minSpawnTime;
    public int maxSpawnTime;
    private void Start()
    {
        _spwLocation = Random.Range(0, 2);
        
    }
    void Update()
    {
        if (_spawnAble) StartCoroutine(SpawnCar());
    }

    IEnumerator SpawnCar()
    {
        _spawnAble = false;
        if (_spwLocation == 0) Instantiate(_car, new Vector2(-30, transform.position.y), Quaternion.identity);
        else if (_spwLocation == 1) Instantiate(_car, new Vector2(30, transform.position.y), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(minSpawnTime,maxSpawnTime));
        _spawnAble = true;
    }
}
