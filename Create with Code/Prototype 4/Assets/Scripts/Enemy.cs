using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    private GameObject player;
    private float speed=10f;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 loolDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(loolDirection * speed);
        if (transform.position.y < -15)
        {
            Destroy(gameObject);
        }
    }
}
