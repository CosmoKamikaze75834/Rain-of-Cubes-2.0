using UnityEngine;

public class Mediator : MonoBehaviour
{
    [SerializeField] private CubeSpawner _cubeSpawner;
    [SerializeField] private BombSpawner _bombSpawner;

    private void OnEnable()
    {
        _cubeSpawner.Released += Challenge;
    }

    private void OnDisable()
    {
        _cubeSpawner.Released -= Challenge;
    }

    private void Challenge(Cube cube)
    {
        _bombSpawner.Create(cube.transform.position);
    }
}