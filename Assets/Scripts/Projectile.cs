using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject explosion;

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 explosionPos = transform.position;

        Instantiate(explosion, explosionPos, Quaternion.identity);
        Destroy(gameObject);
    }
}
