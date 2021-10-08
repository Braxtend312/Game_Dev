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
    private Rigidbody rb;

    void Awake()
    {
        // get components
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CamLook();
        if(Input.GetButtonDown("Jump"))
            Jump();
    }

    void Move()
    { // get keyboard input with move speed
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        // applying movement to the Rigidbody
        Vector3 dir = transform.right * x + transform.forward * z;
        //jump diretion
        dir = rb.velocity.y;
        //apply direction to camera mivement
        rb.velocity = dir;
    }
    void Jump()
    {
       //cast ray to gound
        Ray ray = new Ray(transform.position, Vector3.down);
        // check Ray length to jump
        if(Physics.Raycast(ray, 1.1f))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    void CamLook()
    { // get mouse input so we can look around with the mouse
        float y = Input.GetAxis("Mouse X") * lookSensitivity;
        rotX += Input.GetAxis("Mouse Y") * lookSensitivity;

        // Restrict the verticle rotation of the camera
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);

        // applying the rotation to camera
        cam.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;

    }
}
