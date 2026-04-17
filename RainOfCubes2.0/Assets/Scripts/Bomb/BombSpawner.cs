using System;
using UnityEngine;

public class BombSpawner : BaseSpawner<Bomb>
{
    private int _spawnCount;

    public event Action<int> NumberObjectsChanged;

    public void Create(Vector3 position)
    {
        Bomb bomb = GetObject();

        _spawnCount++;
        NumberObjectsChanged?.Invoke(_spawnCount);

        bomb.transform.position = position;
        bomb.Dissapeared += ReleaseObject;
        bomb.Activate();
    }

    protected override void ReleaseObject(Bomb bomb)
    {
        bomb.Dissapeared -= ReleaseObject;
        base.ReleaseObject(bomb);
    }
}