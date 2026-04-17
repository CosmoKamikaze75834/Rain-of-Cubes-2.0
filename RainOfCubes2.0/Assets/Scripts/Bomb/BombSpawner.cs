using System;
using UnityEngine;

public class BombSpawner : BaseSpawner<Bomb>
{
    public void Create(Vector3 position)
    {
        Bomb bomb = Spawn(position);

        bomb.Dissapeared += ReleaseObject;
        bomb.Activate();
    }

    protected override void ReleaseObject(Bomb bomb)
    {
        bomb.Dissapeared -= ReleaseObject;
        base.ReleaseObject(bomb);
    }
}