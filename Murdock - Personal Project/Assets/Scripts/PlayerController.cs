using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed=100;
    private Rigidbody playerRb;
    private float horizontalInput;
    private float verticalInput;
    private float bound = 15;
    private float a = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }
    void MovePlayer()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }
    void ConstrainPlayerPosition()
    {
        if (transform.position.x > bound)
        {
            playerRb.AddForce(Vector3.left * a, ForceMode.Impulse);
            transform.position = new Vector3(bound, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -bound)
        {
            playerRb.AddForce(Vector3.right * a, ForceMode.Impulse);
            transform.position = new Vector3(-bound, transform.position.y, transform.position.z);
        }
        else if (transform.position.z > bound)
        {
            playerRb.AddForce(Vector3.back * a, ForceMode.Impulse);
            transform.position = new Vector3(transform.position.x, transform.position.y, bound);
        }
        else if (transform.position.z < -bound)
        {
            playerRb.AddForce(Vector3.forward * a, ForceMode.Impulse);
            transform.position = new Vector3(transform.position.x, transform.position.y, -bound);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collided with enemy!");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
        }
    }
}
