using UnityEngine;
using Q3Movement;
using System.Collections.Generic;

public class ExplosionController : MonoBehaviour
{
    [SerializeField] private float radius = 5.0F;
    [SerializeField] private float power = 10.0F;
    [SerializeField] private LayerMask lm;
    [SerializeField] private float downSpeed;
    private List<GameObject> players = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, lm);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                var controller = hit.GetComponent<Q3PlayerController>();
                if(players.Contains(hit.gameObject) == false) players.Add(hit.gameObject);
                Vector3 vel = Explosion.Calculate(hit.transform.position, transform.position, power);
                if(controller != null)
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
                if(player != null) player.GetComponent<Q3PlayerController>().explosion = Vector3.zero;
            }
            Destroy(gameObject);
        }
    }
}
