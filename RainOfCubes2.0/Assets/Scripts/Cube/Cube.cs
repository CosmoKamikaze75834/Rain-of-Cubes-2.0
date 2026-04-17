using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
public class Cube : MonoBehaviour
{            
    [SerializeField] private ColorChanger _color;

    private Rigidbody _rigidbody;

    private int _maxTime = 5;
    private int _minTime = 2;

    private bool _isConflict = false;

    public event Action<Cube> Dissapeared;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isConflict == true)
        {
            return;
        }

        if (collision.gameObject.TryGetComponent<Platform>(out _))
        {
            _color.Apply();
            StartCoroutine(LyingPlatform());
            _isConflict = true;
        }
    }

    public void ResetPosition()
    {
        _isConflict = false;

        _color.Reset();

        _rigidbody.velocity = Vector3.zero; 
        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.rotation = Quaternion.identity;
    }

    private IEnumerator LyingPlatform()
    {
        float delay = Random.Range(_minTime, _maxTime);
        WaitForSeconds _wait = new WaitForSeconds(delay);

        yield return _wait;
        Dissapeared?.Invoke(this);
    }
}