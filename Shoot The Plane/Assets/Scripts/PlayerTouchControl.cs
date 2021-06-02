using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchControl : MonoBehaviour
{
    private Transform m_transform;
    private Camera m_camera;
    private float speedMove = 0.5f;
    private Vector2 delta_position = Vector2.up * 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        m_transform = transform;
        m_camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            m_transform.position = Vector3.MoveTowards(m_transform.position, (Vector2)m_camera.ScreenToWorldPoint(Input.mousePosition) + delta_position, speedMove);
        }
    }
}
