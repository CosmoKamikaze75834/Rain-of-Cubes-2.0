using System;
using UnityEngine;
using UnityEngine.Pool;

public abstract class BaseSpawner <T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 5;

    private ObjectPool<T> _pool;

    protected int _createCount;
    private int _activeCount;

    public event Action<int> NumberObjectsCreatedChanged;
    public event Action<int> NumberObjectsActiveChanged;

    private void Awake()
    {
        _pool = new ObjectPool<T>(
        createFunc: () => {
            T prefab = Instantiate(_prefab);
            _createCount++;
            NumberObjectsCreatedChanged?.Invoke(_createCount);
            return prefab;
        },
        actionOnGet: (prefab) => PrepareObject(prefab),
        actionOnRelease: (prefab) => prefab.gameObject.SetActive(false),
        actionOnDestroy: (prefab) => Destroy(prefab.gameObject),
        collectionCheck: true,
        defaultCapacity: _poolCapacity,
        maxSize: _poolMaxSize);
    }

    protected virtual void PrepareObject(T item)
    {
        item.gameObject.SetActive(true);
        _activeCount++;
        NumberObjectsActiveChanged?.Invoke(_activeCount);
    }

    protected virtual T GetObject()
    {
        return _pool.Get();
    }

    protected virtual void ReleaseObject(T item)
    {
        _pool.Release(item);
        _activeCount--;
        NumberObjectsActiveChanged?.Invoke(_activeCount);
    }
}