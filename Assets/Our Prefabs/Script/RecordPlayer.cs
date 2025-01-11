using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RecordPlayer : MonoBehaviour
{

    public GameObject handle; // Reference to the handle
    public GameObject platter; // Reference to the platter
    public AudioSource recordPlayerAudio; // Reference to the audio source of the record player
    public XRSocketInteractor socket; // Reference to the XRSocketInteractor

    //public GameObject recordRedPrefab; // Prefab for the red record
    //public GameObject recordBluePrefab; // Prefab for the blue record

    public float spinSpeed = 50.0f;
    private bool isPlayerOn = false; // boolean to track on or off
    private GameObject currentRecord; // Tcurrent record
    private Vector3 originalHandleRotation;

    // Record Arm Movement
    public float rotateSpeed = 25.0f;
    public float maxAngle = 0.941954f;
    public float minAngle = 0.713154f;
    public float handleRot;

    void Start()
    {
        originalHandleRotation = handle.transform.eulerAngles;
        socket.selectEntered.AddListener(OnRecordPlaced);
        socket.selectExited.AddListener(OnRecordRemoved);
    }

    void Update()
    {
        handleRot = handle.transform.rotation.y;

        if (isPlayerOn && currentRecord != null)
        {
            // Rotate the record around its up axis (Y-axis)
            //platter.transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
            //currentRecord.transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
            if (handle.transform.rotation.y < maxAngle)
            {
                handle.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);
            }

            if (handle.transform.rotation.y >= maxAngle)
            {
                platter.transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
            }
        }

        if(currentRecord == null)
        {
            if (handle.transform.rotation.y >= minAngle)
            {
                handle.transform.Rotate(Vector3.up, -rotateSpeed * Time.deltaTime);
            }
        }
    }

    public void ToggleRecordPlayer()
    {
        if (currentRecord == null) return; // No record to play

        isPlayerOn = !isPlayerOn;

        if (isPlayerOn)
        {
            // Rotate the handle
            //handle.transform.Rotate(Vector3.up, 60f);
            PlayRecordAudio();
        }
        else
        {
            // Rotate the handle back to its original position
            //handle.transform.eulerAngles = originalHandleRotation;
            StopRecordAudio();
        }
    }

    private void PlayRecordAudio()
    {
        if (recordPlayerAudio.clip != null)
        {
            recordPlayerAudio.Play();
        }
    }

    private void StopRecordAudio()
    {
        recordPlayerAudio.Stop();
    }

    private void OnRecordPlaced(SelectEnterEventArgs args)
    {
        currentRecord = args.interactableObject.transform.gameObject;

        AudioSource recordAudioSource = currentRecord.GetComponent<AudioSource>();
        if (recordAudioSource != null)
        {
            recordPlayerAudio.clip = recordAudioSource.clip;
        }

        ToggleRecordPlayer();
    }

    private void OnRecordRemoved(SelectExitEventArgs args)
    {
        if (isPlayerOn)
        {
            ToggleRecordPlayer();
        }

        currentRecord = null;
        recordPlayerAudio.clip = null;
    }

    
    
}
