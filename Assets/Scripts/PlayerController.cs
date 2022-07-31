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

    // Upgrades
    public GameObject upgradesHolder;
    public List<Upgrade> upgrades;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // FixedUpdate is called once per fixed-framerate frame
    void FixedUpdate()
    {
        // --------------
        // Movement
        // --------------

        // Left or right movement
        float horizontalInput = Input.GetAxis("Horizontal");
        
        // If the user isn't telling the car to move, stop it from moving
        if (horizontalInput == 0)
        {
            foreach (Wheel wheel in wheels)
            {
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

            float RPMSum = 0;
            // Move the car
            foreach (Wheel wheel in wheels)
            {
                wheel.collider.motorTorque = motorTorque;
                RPMSum += wheel.collider.rpm;
            }

            // Animate the wheels
            float avgRPM = RPMSum / wheels.Count; // RPM already includes direction
            Vector3 rotation = new Vector3(avgRPM * Time.deltaTime * RenderRotationSpeed, 0, 0);
            foreach (Wheel wheel in wheels)
            {
                wheel.renderer.transform.Rotate(rotation);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CollectableUpgrade"))
        {
            Upgrade upgrade = other.GetComponent<Upgrade>();
            AddUpgrade(upgrade);
        }
    }


    // Adds an upgrade to the car
    void AddUpgrade(Upgrade upgrade)
    {
        upgrade.OnCollected();
        upgrade.gameObject.transform.SetParent(upgradesHolder.transform);
        upgrades.Add(upgrade);
    }
}


[System.Serializable]
public class Wheel
{
    public WheelCollider collider;
    public MeshRenderer renderer;
}