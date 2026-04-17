using UnityEngine;

public class BombActiveText : BaseText
{
    [SerializeField] private BombSpawner _bombSpawner;

    protected override void Subscribe()
    {
        _bombSpawner.Activated += UpdateUIActive;
    }

    protected override void Unsubscribe()
    {
        _bombSpawner.Activated -= UpdateUIActive;
    }

    protected override void UpdateUI()
    {
        UpdateUIActive(_bombSpawner.ActiveCount);
    }

    private void UpdateUIActive(int value)
    {
        _text.text = "Bomb active - " + value;
    }
}