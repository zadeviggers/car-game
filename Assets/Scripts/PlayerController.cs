using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Constants
    private const float MaxSpeed = 30.0f, Acceleration = 100.5f, WheelTorque = 5.0f;

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

            // Torque to apply to the wheels
            Vector3 wheelRotation = new Vector3(WheelTorque * direction, 0, 0);

            // Animate the wheels turning
            foreach (GameObject wheel in wheels) {
                wheel.transform.Rotate(wheelRotation);
            }
        }
    }
}
