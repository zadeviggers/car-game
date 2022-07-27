using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Constants
    private const float MaxSpeed = 50.0f, Acceleration = 800.5f, WheelSpeed = 10.0f;

    // Components
    private Rigidbody rb;
    private GameObject[] wheels;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        wheels = GameObject.FindGameObjectsWithTag("Wheel");
    }

    // Update is called once per frame
    void Update()
    {
        // --------------
        // Movement
        // --------------

        // Left or right movement
        float horizontalInput = Input.GetAxis("Horizontal");

        // If there is any input...
        if (horizontalInput != 0)
        {
            // This will be multiplied by the acceleration to change the direction
            int direction = 1;
            // If the movement is left, make the multiplier negative
            if (horizontalInput < 0) direction = -1;
            
            // Create a force vector for the acceleration
            Vector3 movementForce = new Vector3(Acceleration * direction, 1);

            // Apply the force
            rb.AddForce(movementForce, ForceMode.Force);

            if (rb.velocity.magnitude > MaxSpeed)
            {
                rb.velocity = rb.velocity.normalized * MaxSpeed;
            }

            // Torque to apply to the wheels
            Vector3 wheelRotation = new Vector3(WheelSpeed * direction, 0, 0);

            // Animate the wheels turning
            foreach (GameObject wheel in wheels) {
                wheel.transform.Rotate(wheelRotation);
            }
        }
    }
}
