using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float ExplosionForce { get; private set; } = 20f;
    public float ExplosionRadius { get; private set; } = 20f;

    public void Explode()
    {
        foreach (Rigidbody explodableObject in GetExplodableObgect())
        {
            explodableObject.AddExplosionForce(ExplosionForce, transform.position, ExplosionRadius);
        }
    }

    public void MultiplierExplosion(float currentExpolosionParametr)
    {
        ExplosionForce *= currentExpolosionParametr;
        ExplosionRadius *= currentExpolosionParametr;
    }

    private List<Rigidbody> GetExplodableObgect()
    {
        float radius = 10f;

        Collider[] hits = Physics.OverlapSphere(transform.position, radius);

        List<Rigidbody> units = new();

        units.AddRange(hits.Where(hit => hit.attachedRigidbody != null).Select(hit => hit.attachedRigidbody));

        return units;
    }
}
