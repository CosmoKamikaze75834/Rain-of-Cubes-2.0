using UnityEngine;

public class BombSpawnedText : BaseText
{
    [SerializeField] private BombSpawner _bombSpawner;

    protected override void Subscribe()
    {
        _bombSpawner.Spawned += UpdateUISpawned;
    }

    protected override void Unsubscribe()
    {
        _bombSpawner.Spawned -= UpdateUISpawned;
    }

    protected override void UpdateUI()
    {
        UpdateUISpawned(_bombSpawner.SpawnCount);
    }

    private void UpdateUISpawned(int value)
    {
        _text.text = "Bomb spawned - " + value;
    }
}
