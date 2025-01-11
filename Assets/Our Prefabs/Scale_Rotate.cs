using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale_Rotate : MonoBehaviour
{

    public float scaleSpeed = 1f;
    public float maxScale = 1.5f;
    public float minScale = 0.5f;

    // Scale and rotate reticle
    void Update()
    {

        // Rotate constantly
        transform.Rotate(0, 1.5f, 0, Space.World);

        // Calculate the new scale value using Mathf.PingPong
        float scaleFactor = Mathf.PingPong(Time.time * scaleSpeed, maxScale - minScale) + minScale; // + minscale as pingpong goes down to 0

        transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

    }
}
