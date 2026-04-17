using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class CubeSpawner : BaseSpawner<Cube>
{
    private const float Delay = 0.4f;

    [SerializeField] private Transform _center;
    [SerializeField] private float _platformWidth;
    [SerializeField] private float _platformDepth;
    [SerializeField] private float _hight = 20;

    private WaitForSeconds _wait = new WaitForSeconds(Delay);
    private float _separator = 2;

    private int _spawnCount;

    public int Counter => _spawnCount;

    public event Action<Cube> Released;

    public event Action<int> NumberObjectsChanged;

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
            ChangeLocation();
            yield return _wait;
        }
    }

    private void ChangeLocation()
    {
        float minX = -_platformWidth / _separator;
        float maxX = +_platformWidth / _separator;

        float minZ = -_platformDepth / _separator;
        float maxZ = +_platformDepth / _separator;

        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        Vector3 positionSpawn = new Vector3(_center.position.x + randomX,
            _center.position.y + _hight,
            _center.position.z + randomZ);

        EstablishPosition(positionSpawn);
    }

    private void EstablishPosition(Vector3 position)
    {
        Cube cube = GetObject();
        _spawnCount++;
        NumberObjectsChanged?.Invoke(_spawnCount);

        cube.Dissapeared += ReleaseObject;
        cube.transform.position = position;
    }
}