using System.Collections;
using Mirror;
using UnityEngine;

public class Projectile : NetworkBehaviour
{
    [SerializeField] private GameObject explosion;
    [SerializeField] private float lifeTime;

    private void Start()
    {
        StartCoroutine(StartLifeTime());
    }
    private void OnCollisionEnter(Collision collision)
    {
        CmdSpawnExplosion();
        
        Destroy(gameObject);
    }

    [Server]
    private void CmdSpawnExplosion()
    {
        GameObject exp = Instantiate(explosion, transform.position, Quaternion.identity);
        NetworkServer.Spawn(exp, exp.GetComponent<NetworkIdentity>().assetId);
    }

    private IEnumerator StartLifeTime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
    
    private void OnDestroy() => NetworkServer.Destroy(gameObject);
}
