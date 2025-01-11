using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingFall : MonoBehaviour
{
    public Rigidbody rb;
    public BoxCollider bc;
    public Vector3 forceDirection;
    public float additionalForce;
    public float torqueForce;
    private PlayQuickSound quickSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        quickSound = GetComponent<PlayQuickSound>();
        rb.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        // Check if the colliding object has the tag "Ball"
        if (other.tag.Equals("Ball"))
        {
            rb.isKinematic = false;
            bc.isTrigger = false;
            Vector3 force = forceDirection.normalized * additionalForce;
            rb.AddForce(force, ForceMode.Impulse);

            Vector3 torque = Vector3.forward * torqueForce;
            rb.AddTorque(torque, ForceMode.Impulse);

            quickSound.Play();
        }
    }
}
