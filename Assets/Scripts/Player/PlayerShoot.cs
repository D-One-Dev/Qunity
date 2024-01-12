using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject _projectile;
    public Transform shootPoint;
    public Transform cameraTransform;
    public float projectileSpeed;
    private NewInput playerInput;
    private void Awake()
    {
        playerInput = new NewInput();
        playerInput.Gameplay.MouseLeftButton.performed += ctx => Shoot();
    }
    private void OnEnable(){playerInput.Enable();}
    private void OnDisable(){playerInput.Disable();}

    private void Shoot()
    {
        GameObject projectile = Instantiate(_projectile, shootPoint.position, shootPoint.rotation);
        projectile.GetComponent<Rigidbody>().velocity = cameraTransform.forward * projectileSpeed;
    }
}
