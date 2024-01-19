using UnityEngine;
using Mirror;
using System.Collections;

public class PlayerShoot : NetworkBehaviour
{
    public GameObject _projectile;
    public Transform shootPoint;
    public Transform cameraTransform;
    public float projectileSpeed;
    private NewInput playerInput;
    private PlayerInventory playerInventory;
    private bool isRecoiling;
    private bool isShooting;
    
    private void Awake()
    {
        playerInput = new NewInput();
        playerInput.Gameplay.MouseLeftButton.started += ctx => isShooting = true;
        playerInput.Gameplay.MouseLeftButton.canceled += ctx => isShooting = false;
    }
    private void Start()
    {
        playerInventory = GetComponent<PlayerInventory>();
    }
    private void OnEnable(){playerInput.Enable();}
    private void OnDisable(){playerInput.Disable();}

    private void FixedUpdate()
    {
        if(isShooting && !isRecoiling)
        {
            Shoot();
            StartCoroutine(Recoil(playerInventory.GetCurrentGun().recoilTime));
        }
    }
    private void Shoot()
    {
        if (!isLocalPlayer) return;
        
        if(playerInventory.GetCurrentAmmo() > 0)
        {
            CmdSpawnProjectile();
            playerInventory.ReduceAmmo();
        }
    }

    [Command]
    private void CmdSpawnProjectile()
    {
        GameObject projectile = Instantiate(_projectile, shootPoint.position, shootPoint.rotation);
        NetworkServer.Spawn(projectile, projectile.GetComponent<NetworkIdentity>().assetId);
        
        projectile.GetComponent<Rigidbody>().velocity = cameraTransform.forward * projectileSpeed;
    }

    private IEnumerator Recoil(float time)
    {
        isRecoiling = true;
        yield return new WaitForSeconds(time);
        isRecoiling = false;
    }
}
