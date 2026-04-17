using UnityEngine;

public class CubeActiveText: BaseText
{
    [SerializeField] private CubeSpawner _cubeSpawner;

    protected override void Subscribe()
    {
        _cubeSpawner.Activated += UpdateUIActive;
    }

    protected override void Unsubscribe()
    {
        _cubeSpawner.Activated -= UpdateUIActive;
    }

    protected override void UpdateUI()
    {
        UpdateUIActive(_cubeSpawner.ActiveCount);
    }

    private void UpdateUIActive(int value)
    {
        _text.text = "Cube active - " + value;
    }
}