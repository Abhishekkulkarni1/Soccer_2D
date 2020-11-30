using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Transform cameraPosition;
    public LayerMask layerTable;
    private Vector3 cameraVector;
    private Vector3 lastKnown;
    

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 100, layerTable))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            transform.position = hit.point;
            lastKnown = new Vector3(transform.position.x, transform.position.y,transform.position.z );
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction*100f , Color.blue);
            transform.position = lastKnown;
        }
        
    }
}
