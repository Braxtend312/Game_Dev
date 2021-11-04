using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public ObjectPool bulletPool;
    public Transform muzzle;

    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;

    public float bulletSpeed;

    public float shootRate;
    public float lastShootTime;
    private bool isPlayer;
    

    void Awake()
    {
        // lock cursor
        Cursor.lockState = CursorLockMode.Locked;

       
        // are we attached to the player
        if(GetComponent<PlayerControler>())
        {
            isPlayer = true;
        }
    }
    // can we shoot a bullet
    public bool CanShoot()
    {
        if(Time.time-lastShootTime >= shootRate)
        {
            if(curAmmo > 0 || infiniteAmmo == true)
            {
                return true;
            }
        }
        return false;
    }

    public void Shoot()
    {
        // adjst shoot time and reduce ammo by one
        lastShootTime = Time.time;
        curAmmo --; 
// creat projectle
        GameObject bullet = bulletPool.GetObject();
        bullet.transform.position = muzzle.position;
        bullet.transform.rotation = muzzle.rotation;        
        // set velocity of bullet
        bullet.GetComponent<Rigidbody>().velocity = muzzle.forward * bulletSpeed;
    }
}