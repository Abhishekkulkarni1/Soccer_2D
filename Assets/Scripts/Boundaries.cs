using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    public GameObject pukObject;
    public Transform pukStartTransform;
    
    public GameObject enemyObject;
    public Transform enemyStartTransform;

    void OnTriggerExit(Collider other)
    {
        Vector3 pukPosition = new Vector3(pukStartTransform.position.x,pukStartTransform.position.y,pukStartTransform.position.z);
        Quaternion pukRotation = pukStartTransform.rotation;
        
        Vector3 enemyPosition = new Vector3(enemyStartTransform.position.x,enemyStartTransform.position.y,enemyStartTransform.position.z);
        Quaternion enemyRotation = enemyStartTransform.rotation;
        
        if (other.gameObject.CompareTag("Puk"))
        {
            Destroy(other.gameObject);
            Instantiate(pukObject, pukPosition, pukRotation);
            
        }
        else if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Instantiate(enemyObject, enemyPosition, enemyRotation);
        }
    }
}
