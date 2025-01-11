using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleRayInteractor : MonoBehaviour
{

    [SerializeField]
    public XRRayInteractor rightRay;

    [SerializeField]
    public XRRayInteractor leftRay;

    [SerializeField]
    public XRDirectInteractor rightDirect;

    [SerializeField]
    public XRDirectInteractor leftDirect;

    public void toggleRightRay()
    {
        if (rightRay.enabled)
        {
            rightRay.enabled = false;
            rightDirect.enabled = true;
        }
        else
        {
            rightRay.enabled = true;
            rightDirect.enabled = false;
        }
    }

    public void toggleLeftRay()
    {
        if (leftRay.enabled)
        {
            leftRay.enabled = false;
            leftDirect.enabled = true;
        }
        else
        {
            leftRay.enabled = true;
            leftDirect.enabled = false;

        }
    }
}
