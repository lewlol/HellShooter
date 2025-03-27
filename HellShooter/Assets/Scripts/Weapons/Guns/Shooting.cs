using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Gun gun;

    //Current Ammo
    float magCount;
    float excessAmmoCount;

    bool canShoot;
    bool isReloading;
    Camera cam;

    private void Start()
    {
        magCount = gun.maxMagCount;
        excessAmmoCount = gun.maxExcessAmmoCount;

        canShoot = true;
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot && !isReloading)
        {
            //Check Ammo Count First
            if(magCount == 0) // -- Force Reload --
            {
                DetermineReload(); //Find out what you need to reload
                return;
            }

            //Shooting a Projectile
            ShootProjectile();

            //Minus a Bullet
            magCount--;

            //Shooting Delay
            StartCoroutine(CanShoot());
        }

        //Reload Button
        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            DetermineReload();
        }
    }
    
    private void ShootProjectile()
    {
        //Instantiate the Bullet
        GameObject bullet = Instantiate(gun.projectile, cam.transform.position, Quaternion.identity);

        //Bullet Direction and Speed
        Vector3 direction = cam.transform.forward;
        direction.Normalize();

        //Apply Direction
        bullet.GetComponent<Rigidbody>().AddForce(direction * gun.bulletSpeed, ForceMode.Impulse);

        //Destroy Bullet after time
        Destroy(bullet, gun.bulletTime);
    }

    private void DetermineReload()
    {
        //If there is no Excess Ammo - STOP CODE
        if (excessAmmoCount == 0)
            return;

        //Calculate the amount of bullets required
        float bulletAmount = gun.maxMagCount - magCount;
        if (bulletAmount > excessAmmoCount) //If the bullets required are more than the excess, we fill the rest of the excess
        {
            StartCoroutine(ReloadGun(excessAmmoCount));
        }
        else //If not then get the required bullets
        {
            StartCoroutine(ReloadGun(bulletAmount));
        }
    }

    IEnumerator ReloadGun(float bulletAmount)
    {
        isReloading = true;
        yield return new WaitForSeconds(gun.reloatTime);
        isReloading = false;

        magCount += bulletAmount;
        excessAmmoCount -= bulletAmount;
    }

    IEnumerator CanShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(gun.shootingDelay);
        canShoot = true;
    }
}
