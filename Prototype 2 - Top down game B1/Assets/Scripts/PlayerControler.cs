using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnSpeed = 20.0f;

    private float hInput;
    private float vInput;
  
    public float xRange = 10.0f;
    public float yRange = 4.5f;

    public GameObject projectile;
    public Transform FirePoint;
    // Update is called once per frame
    void Update()
    {
        // move and rotate player
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.up * speed * Time.deltaTime * vInput);
        transform.Rotate(Vector3.back, turnSpeed * hInput * Time.deltaTime);
        // wall om left side
        if(transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.x);
        
        }
        // right wall
       if(transform.position.x > -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.x);
        
        }
        // top wall
      if(transform.position.x > yRange)
        {
            transform.position = new Vector3(transform.position.x, yRange, transform.position.x);
        
        }
        // bottom wall
       if(transform.position.x > -yRange)
        {
            transform.position = new Vector3(transform.position.x, -yRange, transform.position.x);

        }
        // hit spacebar for a projectile
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile, FirePoint.transform.position, FirePoint.transform.rotation );
        }
    }

}
