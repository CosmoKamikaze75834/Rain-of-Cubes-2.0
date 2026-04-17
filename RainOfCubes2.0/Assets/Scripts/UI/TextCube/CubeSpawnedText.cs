using TMPro;
using UnityEngine;

public class CubeSpawnedText : BaseText
{
    [SerializeField] private CubeSpawner _cubeSpawner;

    protected override void Subscribe()
    {
        _cubeSpawner.Spawned += UpdateUISpawned;
    }

    protected override void Unsubscribe()
    {
        _cubeSpawner.Spawned -= UpdateUISpawned;
    }

    protected override void UpdateUI()
    {
        UpdateUISpawned(_cubeSpawner.SpawnCount);
    }

    private void UpdateUISpawned(int value)
    {
        _text.text = "Cube spawned - " + value;
    }
}