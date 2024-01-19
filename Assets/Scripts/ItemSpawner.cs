using System.Collections;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public bool isGunSpawner;
    public Gun gun;
    public bool isAwailable = true;
    [SerializeField] private float recoilTime;

    public void StartRecoil()
    {
        isAwailable = false;
        StartCoroutine(Recoil(recoilTime));
    }

    private IEnumerator Recoil(float time)
    {
        yield return new WaitForSeconds(time);
        isAwailable = true;
    }
}
