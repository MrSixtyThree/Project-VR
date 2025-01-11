using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class secretRoom : MonoBehaviour
{
    public XRSocketInteractor[] socketInteractors;
    public GameObject hiddenDoor;
    public GameObject wall;
    public Vector3 targetPosWall;
    public Vector3 currentPosWall;
    public Vector3 targetPos;
    public Vector3 currentPos;
    private string expectedName;
    private bool allMatch = false;
    private bool hasOpened = false;
    public PlayQuickSound quickSound;


    private void Awake()
    {
        currentPos = hiddenDoor.transform.position;
        targetPos = currentPos + new Vector3(0, 0, 1.3f);

        currentPosWall = wall.transform.position;
        targetPosWall = currentPosWall + new Vector3(0, 0, 1.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(socketInteractors[0].selectTarget != null){
            expectedName = socketInteractors[0].selectTarget.name; //gets the name of the first book
        }
        
        allMatch = true;
        
        for (int i = 0; i < socketInteractors.Length; i++){ // loop of all the sockets

            if(socketInteractors[i].selectTarget != null){

                if(socketInteractors[i].selectTarget.name == expectedName){
                    allMatch = true;
                }
                else{
                    allMatch = false;
                    break;
                }
            }
            else{
                allMatch = false;
                break;
            }
        }

        if(allMatch && !hasOpened){
            openDoor();
            quickSound.Play();
        }

        if(!allMatch && hasOpened)
        {
            closeDoor();
            quickSound.Play();
        }
        
    }

    void openDoor()
    {
        wall.transform.position = targetPosWall;
        hiddenDoor.transform.position = targetPos;
        hasOpened = true;
    }

    void closeDoor()
    {
        wall.transform.position = currentPosWall;
        hiddenDoor.transform.position = currentPos;
        hasOpened = false;
    }
}
