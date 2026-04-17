using System.Collections.Generic;
using UnityEngine;

public class ExplosionForceApplier : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 50;
    [SerializeField] private float _explosionRadius = 5;

    public void Explode(Bomb bomb)
    {
        if (bomb.TryGetComponent(out Rigidbody component))
        {
            List<Rigidbody> objects = GetObjectsRadius(bomb, component, _explosionRadius);

            foreach (Rigidbody child in objects)
            {
                child.AddExplosionForce(_explosionForce, bomb.transform.position, _explosionRadius);
            }
        }
    }

    private List<Rigidbody> GetObjectsRadius(Bomb bomb, Rigidbody excludedObject, float explosionRadius)
    {
        Vector3 explosionPosition = bomb.transform.position;

        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider collider in colliders)
        {
            if (collider.attachedRigidbody != null && collider.attachedRigidbody != excludedObject && collider.TryGetComponent<Cube>(out _))
            {
                cubes.Add(collider.attachedRigidbody);
            }
        }

        return cubes;
    }
}