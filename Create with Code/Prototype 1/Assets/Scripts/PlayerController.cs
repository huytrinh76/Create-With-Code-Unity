using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;
    [SerializeField] float turnSpeed=45f;
    private float speed;
    private float rpm;
    [SerializeField] float horsePower = 0;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rPMText;
    [SerializeField] List<WheelCollider> allWheels;
    private int wheelsOnGround;
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
        if (IsOnGround())
        {
            playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);
            //Rotates the car based on horizontal input
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);
            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);
            speedometerText.SetText("Speed: " + speed + " km/h");
            rpm = (speed % 30) * 40;
            rPMText.SetText("RPM: " + rpm);
        }
    }
    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach(WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        else 
        { 
            return false; 
        }
    }
}
