using UnityEngine;

public class Puck : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float force = 0.2f;
    private bool _collided = false;
    private Vector3 _currentTransformVector;
    private bool _racket = false;
    private bool _fresh = true; //is the Puck fresh or slow? add some juice


    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody != null)
        {
            _collided = true;
            _racket = collision.gameObject.CompareTag("Player");
            if (!_racket)
            {
                _racket = collision.gameObject.CompareTag("Enemy");
            }
        }
    }


    void FixedUpdate()
    {
        if (_collided && _racket && _fresh)
        {
            _currentTransformVector = transform.position;
            rigidBody.AddForce(_currentTransformVector.normalized * force, ForceMode.Impulse);
            _collided = false;
            _racket = false;
            _fresh = false;
            print("boosted!!");
        }
    }
}