using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public bool playIdleSpin;
    public Vector3 speed;

    private Vector3 idleSpin = new Vector3(0.5f, 0.5f, 0.5f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playIdleSpin) transform.Rotate(idleSpin);
        else transform.Rotate(speed);
    }
}
