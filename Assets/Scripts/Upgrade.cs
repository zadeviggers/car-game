using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Represents an upgrade to the car/player
public class Upgrade : MonoBehaviour
{
    public Vector3 equippedPosition;
    public Quaternion equippedRotation;


    // When the upgrade is colleted
    public void OnCollected(Transform parentTransform)
    {
        // Change tag to avoid re-triggers
        tag = "EquippedUpgrade";

        // Change spin animation to active one from idle one
        Spin spinAnimation = GetComponent<Spin>();
        spinAnimation.playIdleSpin = false;

        // Parent it under player
        transform.SetParent(parentTransform);

        // Update position relative to parent
        transform.localPosition = equippedPosition;
        // Update rotation
        transform.rotation = equippedRotation;
    }
}
