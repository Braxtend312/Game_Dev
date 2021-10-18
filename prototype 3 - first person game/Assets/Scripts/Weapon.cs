using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletProjectile;
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
        // are we attached to the player
        if(GetComponent<PlayerControler>())
        {
            isPlayer = true;
        }
    }
    // can we shoot a bullet
    public bool Canshoot()
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
        lastShootTime = Time.time
        curAmmo --; 

        GameObject Bullet = Instantiate(bulletProjectile, muzzle.position, muzzle.rotation);

        // set velocity of bullet
        bullet.GetComponent<RigidBody>().velocity = muzzle.forward * bulletSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
