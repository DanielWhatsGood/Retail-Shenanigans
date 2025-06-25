using UnityEngine;

public class HideHeadInFirstPerson : MonoBehaviour
{
    [Tooltip("Optional: Assign the camera manually if needed.")]
    public Camera targetCamera;

    void Start()
    {
        if (targetCamera == null)
            targetCamera = GetComponent<Camera>();

        if (targetCamera != null)
        {
            int hiddenLayer = LayerMask.NameToLayer("FirstPersonHidden");
            targetCamera.cullingMask &= ~(1 << hiddenLayer);
            Debug.Log("Hiding FirstPersonHidden layer from this camera.");
        }
        else
        {
            Debug.LogWarning("No camera found on this GameObject.");
        }
    }
}