using UnityEngine;

[CreateAssetMenu(menuName = "Item/Gun")]
public class Gun : Item
{
    [Header("Gun Stats")]
    public GameObject projectile;
    public float bulletSpeed;
    public float bulletTime;
    [Space]
    public float maxMagCount;
    public float maxExcessAmmoCount;
    [Space]
    public float shootingDelay;
    public float reloatTime;
}
