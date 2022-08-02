using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public ParticleSystem destructionParticles;

    public float destructionVelocityMagnatudeThreshold = 10.0f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Destructive"))
        {
            Rigidbody rigidbody = other.GetComponent<Rigidbody>();
            if (rigidbody && rigidbody.velocity.magnitude < destructionVelocityMagnatudeThreshold) return;
            Instantiate(destructionParticles, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
