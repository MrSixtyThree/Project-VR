using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Throw : MonoBehaviour
{
    public float additionalThrowForce = 5.0f; 
    public float collisionThreshold = 2.0f;
    public PlayQuickSound quickSound;

    private XRGrabInteractable grabInteractable;
    private Rigidbody rb;
    private bool isThrown = false;



    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
    }

    private void OnRelease()
    {
        Vector3 releaseVelocity = rb.velocity;
        rb.AddForce(releaseVelocity * additionalThrowForce, ForceMode.Impulse);
        isThrown = true;
    }


    // TODO FIX THIS <3

    
    private void OnCollisionEnter(Collision collision)
    {
        if (isThrown)
        {
            if (rb.velocity.magnitude < collisionThreshold)
            {
                rb.velocity = Vector3.zero;
                isThrown = false;
            }

            quickSound.Play();
            
        }

    }
    
}
