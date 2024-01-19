using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private static int GUN_COUNT = 1;
    public Gun currentGun;
    [SerializeField] private Gun[] guns;
    [SerializeField] private int[] ammo;
    // Start is called before the first frame update
    void Start()
    {
        ammo = new int[GUN_COUNT];
        for (int i = 0; i < GUN_COUNT; i++) ammo[i] = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Spawner"))
        {
            ItemSpawner spawner = other.GetComponent<ItemSpawner>();
            if (spawner.isAwailable)
            {
                if (spawner.isGunSpawner)
                {
                    Gun gun = spawner.gun;
                    switch (gun.gunName)
                    {
                        case "RocketLauncher":
                            ammo[0] += gun.ammoAmount;
                            break;
                        default: break;
                    }
                }

                spawner.StartRecoil();
            }
        }
    }
}
