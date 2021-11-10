using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   public int damage;
   public float lifetime;
   private float shootTime;

    void OnEnable()
    {
        shootTime = Time.time;
    }

    void OnTriggerEnter(Collider other)
    {
        // If the player is hit then deal damage   
        if(other.CompareTag("Player"))
            other.GetComponent<PlayerController>().TakeDamage(damage);
        // If hit deal odamage ti the enemy
        else if(other.CompareTag("Enemy"))
            other.GetComponent<Enemy>().TakeDamage(damage);
        // Disable projectile to use later
        gameObject.SetActive(false);
    }
  
    // Update is called once per frame
    void Update()
    {
        if(Time.time - shootTime >= lifetime)
            gameObject.SetActive(false);        
    }
}