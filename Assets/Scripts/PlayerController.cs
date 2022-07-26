using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Constants
    private const float MaxSpeed = 30.0f, Acceleration = 100.5f;

    // Components
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            int direction = 1;
            if (horizontalInput < 0) direction = -1;
            
            Vector3 force = new Vector3(Acceleration * direction, 0);
            rb.AddForce(force, ForceMode.Force);
        }
    }
}
