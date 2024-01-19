using UnityEngine;

[CreateAssetMenu(menuName = "Gun")]
public class Gun : ScriptableObject
{
    public string gunName;
    public bool isProjectile;
    public GameObject projectile;
    public GameObject gun;
    public int ammoAmount;
    public float recoilTime;
    public int raycastGunDamage;
}
