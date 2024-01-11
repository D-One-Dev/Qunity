using System.Collections;
using UnityEngine;

public class ParticlesLifeTime : MonoBehaviour
{
    [SerializeField] private float lifeTime;
    void Start()
    {
        StartCoroutine(StartLifeTime());
    }

    private IEnumerator StartLifeTime()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
