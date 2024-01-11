using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject _projectile;
    public Transform shootPoint;
    public Transform cameraTransform;
    public float projectileSpeed;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) Shoot();
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(_projectile, shootPoint.position, shootPoint.rotation);
        projectile.GetComponent<Rigidbody>().velocity = projectile.transform.forward * projectileSpeed;
    }
}
