using System;
using System.Collections;
using UnityEngine;

public class CubeSpawner : BaseSpawner<Cube>
{
    private const float Delay = 0.4f;

    [SerializeField] private Position _position;

    private WaitForSeconds _wait = new WaitForSeconds(Delay);

    public event Action<Cube> Released;

    private void Start()
    {
        StartCoroutine(ChangePositionTime());
    }

    protected override void PrepareObject(Cube cube)
    {
        base.PrepareObject(cube);
        cube.ResetPosition();
    }

    protected override void ReleaseObject(Cube cube)
    {
        cube.Dissapeared -= ReleaseObject;
        base.ReleaseObject(cube);
        Released?.Invoke(cube);
    }

    private IEnumerator ChangePositionTime()
    {
        bool isOpen = true;

        while (isOpen)
        {
            Vector3 position = _position.ChangeLocation();
            EstablishPosition(position);
            yield return _wait;
        }
    }

    private void EstablishPosition(Vector3 position)
    {
        Cube cube = Spawn(position);
        cube.Dissapeared += ReleaseObject;
    }
}