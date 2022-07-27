using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Constants
    public float ColliderTorque;
    public float RenderRotationSpeed;

    // Components
    private Rigidbody rb;
    public List<Wheel> wheels;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // --------------
        // Movement
        // --------------

        // Left or right movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float sum = 0;
        // If the user isn't telling the car to move, stop it from moving
        if (horizontalInput == 0)
        {
            foreach (Wheel wheel in wheels)
            {
                sum += wheel.collider.rpm;
                wheel.collider.motorTorque = 0;
            }
        }
        else
        {
            // This will be multiplied by the acceleration to change the direction
            int direction = -1;

            // If the movement is left, make the multiplier negative
            if (horizontalInput < 0) direction = 1;

            // Energy to apply to the wheels
            float motorTorque = ColliderTorque * direction;

            // Rotation to make the wheels visually turn
            Vector3 rotation = new Vector3(RenderRotationSpeed * direction, 0, 0);

            // Move the car
            foreach (Wheel wheel in wheels)
            {
                sum += wheel.collider.rpm;
                wheel.collider.motorTorque = motorTorque;
                wheel.renderer.transform.Rotate(rotation);
            }
        }
        Debug.Log(sum / wheels.Count);
    }
}


[System.Serializable]
public class Wheel
{
    public WheelCollider collider;
    public MeshRenderer renderer;
}