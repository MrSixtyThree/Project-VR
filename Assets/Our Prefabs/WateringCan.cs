using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public PlayContinuousSound soundPlayer;
    public float tiltThreshold = 45.0f;
    private float initialXRotation;
    private bool isPlaying = false;

    void Start()
    {
        initialXRotation = transform.localEulerAngles.x;
        soundPlayer = GetComponent<PlayContinuousSound>();
    }

    void Update()
    {
        float currentXRotation = transform.localEulerAngles.x;
        float deltaRotation = Mathf.Abs(currentXRotation - initialXRotation);

        if(deltaRotation > tiltThreshold && !isPlaying){
            soundPlayer.Play();
            particleSystem.Play();
            isPlaying = true;
        }
        if(deltaRotation < tiltThreshold && isPlaying){
            soundPlayer.Pause();
            particleSystem.Stop();
            isPlaying = false;
        }
    }
}