using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScollingObject : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private float scollSpeed = -1f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(0f, scollSpeed);
    }
}
