using UnityEngine;

public class BombCreatedText : BaseText
{
    [SerializeField] private BombSpawner _bombSpawner;

    protected override void Subscribe()
    {
        _bombSpawner.Created += UpdateUICreated;
    }

    protected override void Unsubscribe()
    {
        _bombSpawner.Created -= UpdateUICreated;
    }

    protected override void UpdateUI()
    {
        UpdateUICreated(_bombSpawner.CreateCount);
    }

    private void UpdateUICreated(int value)
    {
        _text.text = "Bomb created - " + value;
    }
}