using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetObject : MonoBehaviour
{
    public GameObject targetObject;
    [SerializeField] Vector3 initialPosition;
    [SerializeField] Quaternion initialRotation;

    void Start()
    {
        if (targetObject != null)
        {
            initialPosition = targetObject.transform.position;
            initialRotation = targetObject.transform.rotation;
        }
    }

    void Update()
    {

    }

    public void ResetPosition()
    {
        if (targetObject != null)
        {
            targetObject.transform.position = initialPosition;
            targetObject.transform.rotation = initialRotation;
        }
    }
}