using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayGun : MonoBehaviour
{

    public LayerMask layerMask;
    public OVRInput.RawButton shootingButton;
    public LineRenderer linePrefab;
    public Transform shootingPoint;
    public float maxLineDistance = 10;
    public float lineShowTimer = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(shootingButton))
        {
            shoot();
        }
    }

    public void shoot()
    {
        Debug.Log("Pew");

        Ray ray = new Ray(shootingPoint.position, shootingPoint.forward);
        bool hasHit = Physics.Raycast(ray, out RaycastHit hit, maxLineDistance, layerMask);

        Vector3 endPoint = Vector3.zero;

        //stops ray when it finds a collider
        if (hasHit)
        {
            Debug.Log("Ray Collided");
            endPoint = hit.point;
        }
        else
        {
            endPoint = shootingPoint.position + shootingPoint.forward * maxLineDistance;
        }

        LineRenderer line = Instantiate(linePrefab);
        line.positionCount = 2;
        line.SetPosition(0, shootingPoint.position);
        line.SetPosition(1, endPoint);

        Destroy(line.gameObject, lineShowTimer);
    }
}
