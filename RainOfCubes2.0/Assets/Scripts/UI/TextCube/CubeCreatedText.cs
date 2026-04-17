using UnityEngine;

public class CubeCreatedText: BaseText
{
    [SerializeField] private CubeSpawner _cubeSpawner;

    protected override void Subscribe()
    {
        _cubeSpawner.Created += UpdateUICreated;
    }

    protected override void Unsubscribe()
    {
        _cubeSpawner.Created -= UpdateUICreated;
    }

    protected override void UpdateUI()
    {
        UpdateUICreated(_cubeSpawner.CreateCount);
    }

    private void UpdateUICreated(int value)
    {
        _text.text = "Cube created - " + value;
    }
}