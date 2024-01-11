using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private float lifeTime;

    private void Start()
    {
        StartCoroutine(StartLifeTime());
    }
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 explosionPos = transform.position;

        Instantiate(explosion, explosionPos, Quaternion.identity);
        Destroy(gameObject);
    }

    private IEnumerator StartLifeTime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
