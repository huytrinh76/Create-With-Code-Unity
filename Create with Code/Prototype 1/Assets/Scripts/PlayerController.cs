using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;
    [SerializeField] float turnSpeed=45f;
    //[SerializeField] float speed = 20f;
    [SerializeField] float horsePower = 0;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //Move the vehicle forward based on  vertical input
        //transform.Translate(Vector3.forward*Time.deltaTime*speed*forwardInput);
        playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
        //Rotates the car based on horizontal input
        transform.Rotate(Vector3.up, turnSpeed*Time.deltaTime*horizontalInput);
    }
}
