using System.Collections;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public bool isGunSpawner;
    public Gun gun;
    public bool isAwailable = true;
    [SerializeField] private float recoilTime;
    [SerializeField] private GameObject item;

    public void StartRecoil()
    {
        StartCoroutine(Recoil(recoilTime));
    }

    private IEnumerator Recoil(float time)
    {
        isAwailable = false;
        item.SetActive(false);
        yield return new WaitForSeconds(time);
        isAwailable = true;
        item.SetActive(true);
    }
}
