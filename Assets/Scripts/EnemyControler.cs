using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    private Transform puk;
    public Transform scorePosition;
    private GameObject pukObject;
    public bool isPlayer = false;
    public float speed = 10f;
    
    void Update()
    {
        if (!isPlayer)
        {
            if (pukObject == null)
                pukObject = GameObject.FindWithTag("Puk");

            puk = pukObject.GetComponent<Transform>();

            Vector3 pukPosition = new Vector3(puk.position.x, puk.position.y, puk.position.z);
            Vector3 scoreVector =
                new Vector3(scorePosition.position.x, scorePosition.position.y, scorePosition.position.z);

            Debug.DrawLine(pukPosition, scoreVector, Color.green);

            Vector3 halfDistanceBetweenPoints = (pukPosition + scoreVector) / 2;
            Vector3 xVector = new Vector3(halfDistanceBetweenPoints.x, 1.705f, -4.44f);
            transform.position = xVector;
        }
        else
        {
            float horizontalMovement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float verticalMovement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            transform.Translate(horizontalMovement,0,verticalMovement);
        }

    }
}
