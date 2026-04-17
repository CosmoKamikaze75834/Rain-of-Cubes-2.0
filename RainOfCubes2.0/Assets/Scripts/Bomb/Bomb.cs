using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Renderer))]
public class Bomb : MonoBehaviour
{
    [SerializeField] private ExplosionForceApplier _applier;
    [SerializeField] private ColorChanger _colorChanger;

    private Coroutine _coroutine;

    private int _minTime = 2;
    private int _maxTime = 5;

    public event Action<Bomb> Dissapeared;

    public void Activate()
    {
        _colorChanger.ResetTransparency();

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        StartCoroutine(StartLifetime());
    }

    private IEnumerator StartLifetime()
    {
        float lifeTime = Random.Range(_minTime, _maxTime);
        float elapsedTime = 0f;

        while (lifeTime > elapsedTime)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / lifeTime;
            progress = Mathf.Clamp01(progress);

            _colorChanger.EstablishTransparency(progress);

            yield return null;
        }

        _applier.Explode(this);

        Dissapeared?.Invoke(this);
        _coroutine = null;
    }
}