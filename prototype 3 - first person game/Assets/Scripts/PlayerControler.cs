using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{   
    // movement 
    public float moveSpeed; // move speed. literally
    public float jumpForce; // how high you can jump
    // camera 
    public float lookSensitivity; // mouse movement sensitivity
    public float maxLookX; // lowest we can look
    public float minLookX; // highest we can look
    private float rotX; // current x position of the camera

    // components 
    private Camera cam;
    private RigidBody rb;

    void Awakee()
    {
        // get components
        cam = Cmer.main;
        rb = GetComponent<RigidBody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = new Vector3(x, rb.velocity.y, z);
    }
}
