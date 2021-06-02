using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D collider2D;
    private float groundVerticalLength;
    // Start is called before the first frame update
    private void Awake()
    {
        collider2D=GetComponent<BoxCollider2D>();
        groundVerticalLength = collider2D.size.y;
    }

    // Update is called once per frame
    private void Update()
    {
        if (transform.position.y < -groundVerticalLength)
        {
            RepositionBackground();
        }
    }
    private void RepositionBackground()
    {
        Vector2 groundOffSet = new Vector2(0f, groundVerticalLength * 2);
        transform.position = (Vector2)transform.position + groundOffSet;
    }
}
