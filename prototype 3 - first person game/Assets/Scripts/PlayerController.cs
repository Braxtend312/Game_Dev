using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Stats")]

    // movement speed in units per second
    
    public float moveSpeed;
    
    //orce applied upwards
    public float jumpForce;

    public int curHp;
    public int  maxHp;

    [Header("Mouse look")]
   
   // look sensitivity
    public float lookSensitivity;           
    
    // Lowest down we can look
    public float maxLookX;                  
    
    // Highest up we can look
    public float minLookX;                  
 
 // x rotation of the camera
    private float rotX;                    

    private Camera camera;
    private Rigidbody rb;
    private Weapon weapon;

    void Awake()
    {
        weapon = GetComponent<Weapon>();
    }
    // Start is called before the first frame update
    void Start()
    {
       //get components
       camera = Camera.main;
       rb = GetComponent<Rigidbody>(); 
    }
    // Damage to the player
    public void TakeDamage(int damage)
    {
        curHp -= damage;

        if(curHp <= 0)
            Die();
    }
    // If players health hits zero or below then run die
    void Die()
    {
        
    }    
   
    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        // Move direction relative to camera
        Vector3 dir = transform.right * x + transform.forward * z;    
       
        dir.y = rb.velocity.y;        
        rb.velocity = dir;        
    }

    void CamLook()
    {
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;
         
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);
        camera.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;
    }

    void Jump()
    {
      Ray ray = new Ray(transform.position, Vector3.down); 

      if(Physics.Raycast(ray, 1.1f))
      {
          // Add force to jump
          rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
      }
        
    }
    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook(); 

        // Fire button 
        if(Input.GetButton("Fire1"))
        {
          if(weapon.CanShoot())
            weapon.Shoot();  
        }
        // Jump button
         if(Input.GetButtonDown("Jump"))
            Jump();          
    }
}