using UnityEngine;
using Q3Movement;
using System.Collections.Generic;

public class ExplosionController : MonoBehaviour
{
    [SerializeField] private float radius = 5.0F;
    [SerializeField] private float power = 10.0F;
    [SerializeField] private LayerMask lm;
    [SerializeField] private float downSpeed;
    [SerializeField] private int maxDamage;
    private List<GameObject> players = new List<GameObject>();
    [SerializeField] private GameObject explosionPrefab;
    void Start()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
    }
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, lm);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            CharacterController cc = hit.GetComponent<CharacterController>();
            if (rb != null)
            {
                Vector3 vel = Explosion.Calculate(hit.transform.position, transform.position, power);
                rb.velocity += vel;
            }
            else if(cc != null)
            {
                var controller = hit.GetComponent<NewPlayerControls>();
                if (players.Contains(hit.gameObject) == false && controller != null)
                {
                    players.Add(hit.gameObject);
                    Vector3 hitPoint = cc.gameObject.GetComponent<Collider>().ClosestPoint(transform.position);
                    if(transform.position - hitPoint != Vector3.zero)
                    {
                        Vector3 vect = transform.position - hitPoint;
                        //vect.x *= cc.radius;
                        //vect.y *= cc.radius;
                        //vect.y *= cc.height;
                        float dinst = vect.magnitude*10;
                        if((int) dinst > 0)
                        {
                            int dmg = maxDamage / (int)dinst;
                            hit.gameObject.GetComponent<PlayerHealth>().DecreaseHealth(dmg);
                        }
                    }
                }
                Vector3 vel = Explosion.Calculate(hit.transform.position, transform.position, power);
                if (controller != null)
                {
                    controller.explosion = vel;
                }
                else rb.velocity += vel;
            }
        }

        power -= downSpeed;
        if (power <= 0)
        {
            foreach (GameObject player in players)
            {
                if(player != null) player.GetComponent<NewPlayerControls>().explosion = Vector3.zero;
            }
            Destroy(gameObject);
        }
    }
}
