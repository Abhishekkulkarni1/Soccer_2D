using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLogic : MonoBehaviour
{
    public static int playerScore { get;  private set; }
    public static int enemyScore { get;  private set; }
    public GameObject pukObject;
    public Transform pukStartTransform;
    public bool playerGate;


    void OnTriggerEnter(Collider other)
    {
        Vector3 pukPosition = new Vector3(pukStartTransform.position.x,pukStartTransform.position.y,pukStartTransform.position.z);
        Quaternion pukRotation = pukStartTransform.rotation;

        if (other.gameObject.CompareTag("Puk"))
        {
            Destroy(other.gameObject);
            Instantiate(pukObject, pukPosition, pukRotation);
            if (playerGate)
            {
                enemyScore++;
                print("Enemy Score is " + enemyScore);
            }
            else
            {
                playerScore++;
                print("Player Score is " + playerScore);
            }
        }
    }

}
