using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float speed=12f;
    private Collider2D _collider2D;
    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void Activate()
    {
        _rigidbody2D.velocity = transform.up * speed;
    }
}
