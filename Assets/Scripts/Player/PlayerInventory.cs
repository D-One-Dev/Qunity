using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    private static int GUN_COUNT = 6;
    public int currentGun;
    [SerializeField] private Gun[] guns;
    [SerializeField] private int[] ammo;
    [SerializeField] private TMP_Text ammoText;
    [SerializeField] private Image ammoImage;
    [SerializeField] private Image[] gunsImages;
    void Start()
    {
        ammo = new int[GUN_COUNT];
        for (int i = 0; i < GUN_COUNT; i++) ammo[i] = 0;
        UpdateUI();
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
                        case "RailGun":
                            ammo[1] += gun.ammoAmount;
                            break;
                        case "NailGun":
                            ammo[2] += gun.ammoAmount;
                            break;
                        case "LightningGun":
                            ammo[3] += gun.ammoAmount;
                            break;
                        case "Shotgun":
                            ammo[4] += gun.ammoAmount;
                            break;
                        case "Machinegun":
                            ammo[5] += gun.ammoAmount;
                            break;
                        default: {Debug.LogError("Gun with such name does not exist");break;}
                    }
                }

                spawner.StartRecoil();
                UpdateUI();
            }
        }
    }

    private void UpdateUI()
    {
        Gun gun = guns[currentGun];
        ammoImage.color = gun.gunColor;
        ammoText.text = ammo[currentGun].ToString();
        for(int i = 0; i < GUN_COUNT; i++)
        {
            if (ammo[i] > 0) gunsImages[i].color = new Color(gunsImages[i].color.r, gunsImages[i].color.g, gunsImages[i].color.b, 1f);
            else gunsImages[i].color = new Color(gunsImages[i].color.r, gunsImages[i].color.g, gunsImages[i].color.b, .1f);
        }
    }

    public int GetCurrentAmmo()
    {
        return ammo[currentGun];
    }

    public void ReduceAmmo()
    {
        ammo[currentGun] -= 1;
        UpdateUI();
    }

    public Gun GetCurrentGun()
    {
        return guns[currentGun];
    }

    public void NextGun()
    {
        Debug.Log("next");
        currentGun++;
        if (currentGun >= GUN_COUNT) currentGun = 0;
        UpdateUI();
    }

    public void PreviousGun()
    {
        Debug.Log("prev");
        currentGun--;
        if (currentGun < 0) currentGun = GUN_COUNT-1;
        UpdateUI();
    }
}
