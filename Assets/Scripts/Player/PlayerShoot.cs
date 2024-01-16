using UnityEngine;
using Mirror;

public class PlayerShoot : NetworkBehaviour
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
        if (!isLocalPlayer) return;
        
        CmdSpawnProjectile();
    }

    [Command]
    private void CmdSpawnProjectile()
    {
        GameObject projectile = Instantiate(_projectile, shootPoint.position, shootPoint.rotation);
        NetworkServer.Spawn(projectile, projectile.GetComponent<NetworkIdentity>().assetId);
        
        projectile.GetComponent<Rigidbody>().velocity = cameraTransform.forward * projectileSpeed;
    }
}
