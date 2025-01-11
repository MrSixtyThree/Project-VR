
using UnityEngine;

public class Glow : MonoBehaviour
{
    [Tooltip("The material that's switched to.")]
    public Material otherMaterial = null;

    private bool usingOther = false;
    private MeshRenderer meshRenderer = null;
    private Material originalMaterial = null;
    public Light lamp1;
    public Light lamp2;
    public Light lamp3;

    void Start()
    {
        lamp1.enabled = false;
        lamp2.enabled = false;
        lamp3.enabled = false;
    }
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;
    }

    public void SetOtherMaterial()
    {
        usingOther = true;
        meshRenderer.material = otherMaterial;
    }

    public void SetOriginalMaterial()
    {
        usingOther = false;
        meshRenderer.material = originalMaterial;
    }

    public void ToggleMaterial()
    {
        usingOther = !usingOther;
        lamp1.enabled = !lamp1.enabled;
        lamp2.enabled = !lamp2.enabled;
        lamp3.enabled = !lamp3.enabled;

        if (usingOther)
        {
            meshRenderer.material = otherMaterial;

        }
        else
        {
            meshRenderer.material = originalMaterial;
            lamp1.enabled = false;
            lamp2.enabled = false;
            lamp3.enabled = false;
        }
    }
}
