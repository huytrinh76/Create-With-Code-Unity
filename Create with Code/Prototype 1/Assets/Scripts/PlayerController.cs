using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float forwardInput;
    private float horizontalInput;
    [SerializeField] float turnSpeed=45f;
    [SerializeField] float speed = 20f;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        //Move the vehicle forward based on  vertical input
        transform.Translate(Vector3.forward*Time.deltaTime*speed*forwardInput);
        //Rotates the car based on horizontal input
        transform.Rotate(Vector3.up, turnSpeed*Time.deltaTime*horizontalInput);
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
    }
}
