using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Represents an upgrade to the car/player
public class Upgrade : MonoBehaviour
{
    public Vector3 equippedPosition;
    public Quaternion equippedRotation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // When the upgrade is colleted
    public void OnCollected(Transform parentTransform)
    {
        tag = "EquippedUpgrade";
        transform.SetParent(parentTransform);
        // Werid Quaternion stuff. This functions just takes an x, y, and z and creates a quaternion.
        transform.localPosition = equippedPosition;
        transform.rotation = equippedRotation;
    }
}
