using UnityEngine;

public class TextBomb : BaseText
{
    [SerializeField] private BombSpawner _bombSpawner;

    protected override void Subscribe()
    {
        switch (_counterType)
        {
            case CounterType.Spawned:
                _bombSpawner.NumberObjectsChanged += Change;
                break;

            case CounterType.Created:
                _bombSpawner.NumberObjectsCreatedChanged += Change;
                break;

            case CounterType.Active:
                _bombSpawner.NumberObjectsActiveChanged += Change;
                break;
        }
    }

    protected override void Unsubscribe()
    {
        switch (_counterType)
        {
            case CounterType.Spawned:
                _bombSpawner.NumberObjectsChanged -= Change;
                break;

            case CounterType.Created:
                _bombSpawner.NumberObjectsCreatedChanged -= Change;
                break;

            case CounterType.Active:
                _bombSpawner.NumberObjectsActiveChanged -= Change;
                break;
        }
    }
}