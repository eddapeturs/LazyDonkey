﻿using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float m_Speed = 2000.0f;             // Arrow speed
    public Transform m_Tip = null;              // Reference to arrow tip

    private Rigidbody m_Rigidbody = null;       // Rigidbody attached to arrow
    private bool m_IsStopped = true;            // Flag for if the arrow is flying
    private Vector3 m_LastPosition = Vector3.zero;



    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (m_IsStopped)
        {
            return;
        }

        // Rotate
        m_Rigidbody.MoveRotation(Quaternion.LookRotation(m_Rigidbody.velocity, transform.up));

        // Collision
        if(Physics.Linecast(m_LastPosition, m_Tip.position))
        {
            Stop();
        }

        // Store Position
        m_LastPosition = m_Tip.position;
    }


    private void Stop()
    {
        m_IsStopped = true;
        m_Rigidbody.isKinematic = true;
        m_Rigidbody.useGravity = false;
    }

    // Called from bow
    public void Fire(float pullValue)
    {
        m_IsStopped = false;
        transform.parent = null;    // No longer attached to bow

        m_Rigidbody.isKinematic = false;
        m_Rigidbody.useGravity = true;
        m_Rigidbody.AddForce(transform.forward * (pullValue * m_Speed));    // Add force that goes forward

        Destroy(gameObject, 5.0f); // Delete arrow after 5 sec
    }


}
