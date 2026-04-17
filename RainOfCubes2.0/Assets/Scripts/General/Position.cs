using UnityEngine;

public class Position : MonoBehaviour
{
    [SerializeField] private Transform _center;
    [SerializeField] private float _platformWidth;
    [SerializeField] private float _platformDepth;
    [SerializeField] private float _hight = 20;

    private float _separator = 2;

    public Vector3 ChangeLocation()
    {
        float minX = -_platformWidth / _separator;
        float maxX = +_platformWidth / _separator;

        float minZ = -_platformDepth / _separator;
        float maxZ = +_platformDepth / _separator;

        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        return new Vector3(_center.position.x + randomX,
            _center.position.y + _hight,
            _center.position.z + randomZ);
    }
}