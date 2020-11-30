using UnityEngine;
using UnityEngine.Serialization;

public class EnemyController : MonoBehaviour
{
    // TODO simplify puck and puckObject
    // (why not make puck public and access the GameObject via puck.gameObject)
    private Transform _puck;

    public Transform score;

    private GameObject _puckObject;
    public bool isPlayer = false;
    public float speed = 10f;

    void Update()
    {
        if (!isPlayer)
        {
            if (_puckObject == null)
                _puckObject = GameObject.FindWithTag("Puck");

            _puck = _puckObject.GetComponent<Transform>();

            Vector3 puckPosition = _puck.position;
            Vector3 scoreVector = score.position;

            Debug.DrawLine(puckPosition, scoreVector, Color.green);

            Vector3 halfDistanceBetweenPoints = (puckPosition + scoreVector) / 2;

            // TODO remove or explain magic constants ^^
            transform.position = new Vector3(halfDistanceBetweenPoints.x, 1.705f, -4.44f);
        }
        else
        {
            float horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float verticalMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            transform.Translate(horizontalMovement, 0, verticalMovement);
        }
    }
}