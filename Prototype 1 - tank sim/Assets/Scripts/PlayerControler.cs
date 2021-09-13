using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
   public float speed = 10.01;
   public float turnspeed;
   public float h1nput;
   public float v1nput;

    // Update is called once per frame
    void Update()
    {
        h1nput = Input.GetAxis[hoizontal];
        h1nput = Input.GetAxis[vertical];
        transform.Rotate(Vector3.up, turnSpeed * hIput * Time.deltaTime);
        transform.Translate(Vector3.Forward * Speed * vIput * Time.deltaTime);
    }
}
