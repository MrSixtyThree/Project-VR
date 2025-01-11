using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{

    public float maxSpeed = 350.0f;
    public float accelerationRate = 50.0f;
    public float decelerationRate = 25.0f;
    public float currentSpeed = 0.0f;
    public bool isSpinning = false;
    public AudioSource sound;

    // Update is called once per frame
    void Update()
    {
        if (isSpinning)
        {
            // Accelerate the fan speed gradually
            currentSpeed = Mathf.MoveTowards(currentSpeed, maxSpeed, accelerationRate * Time.deltaTime);
        }
        else
        {
            // Decelerate the fan speed gradually when stopped
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0.0f, decelerationRate * Time.deltaTime);

        }

        // Rotate the fan based on the current speed
        transform.Rotate(Vector3.up, currentSpeed * Time.deltaTime);
    }

    public void ToggleFan()
    {
        isSpinning = !isSpinning;

        if (isSpinning)
        {
            // Start playing the fan start audio clip
            sound.Play();
        }
        else
        {
            // Start playing the fan stop audio clip
            sound.Stop();
        }
    }

}
