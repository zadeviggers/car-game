using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The position that the upgrade is in on the car
public enum UpgradePosition
{
    Front,
    Top,
    Back,
    Body
}

// Represents an upgrade to the car/player
public class Upgrade : MonoBehaviour
{
    public UpgradePosition position;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When the upgrade is colleted
    public void OnCollected()
    {
        if (!CompareTag("CollectableUpgrade")) return;
        tag = "EquipedUpgrade";
    }
}
