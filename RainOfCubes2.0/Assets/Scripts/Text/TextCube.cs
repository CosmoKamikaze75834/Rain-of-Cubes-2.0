using TMPro;
using UnityEngine;

public class TextCube : BaseText
{
    [SerializeField] private CubeSpawner _cubeSpawner;

    protected override void Subscribe()
    {
        switch (_counterType)
        {
            case CounterType.Spawned:
                _cubeSpawner.NumberObjectsChanged += Change;
                break;

            case CounterType.Created:
                _cubeSpawner.NumberObjectsCreatedChanged += Change;
                break;

            case CounterType.Active:
                _cubeSpawner.NumberObjectsActiveChanged += Change;
                break;
        }
    }

    protected override void Unsubscribe()
    {
        switch (_counterType)
        {
            case CounterType.Spawned:
                _cubeSpawner.NumberObjectsChanged -= Change;
                break;

            case CounterType.Created:
                _cubeSpawner.NumberObjectsCreatedChanged -= Change;
                break;

            case CounterType.Active:
                _cubeSpawner.NumberObjectsActiveChanged -= Change;
                break;
        }
    }
}