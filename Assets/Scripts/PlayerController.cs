using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public LayerMask layerTable;
    private Vector3 _cameraVector;
    private Vector3 _lastKnown;
    private Camera _camera;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        _camera = Camera.main;
    }

    private void FixedUpdate()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        // inline "out var" declaration instead of writing RaycastHit hit;
        if (Physics.Raycast(ray, out var hit, 100, layerTable))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);

            // this is the same as
            //   transform.position = hit.point;
            //   _laskKnown = transform.position;
            // however its more efficient, since transform.position does not need to be queried
            // transform.position = 
            _lastKnown = hit.point;
            _rigidbody.MovePosition(_lastKnown);
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100f, Color.blue);
            // transform.position = _lastKnown;
            _rigidbody.MovePosition(_lastKnown);
        }
    }
}