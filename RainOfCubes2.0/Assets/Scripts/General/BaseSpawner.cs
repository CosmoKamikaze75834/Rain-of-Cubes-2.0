using System;
using TMPro;
using UnityEngine;

public abstract class BaseSpawner<T> : UniqueSpawner<T> where T : MonoBehaviour
{
    private int _spawnCount;

    public int SpawnCount => _spawnCount;

    public event Action<int> Spawned;

    protected T Spawn(Vector3 position)
    {
        T item = GetObject();

        _spawnCount++;
        Spawned?.Invoke(_spawnCount);

        item.transform.position = position;

        return item;
    }
}