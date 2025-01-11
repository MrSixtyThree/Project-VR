using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flaslight_glow : MonoBehaviour
{

    public Light flashlight;
    // Start is called before the first frame update
    void Start()
    {
        flashlight.enabled = false;
    }

    public void ToogleFlashlight()
    {
        flashlight.enabled = !flashlight.enabled;
    }
}
