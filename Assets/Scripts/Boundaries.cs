using UnityEngine;
using UnityEngine.Serialization;

public class Boundaries : MonoBehaviour
{
    public GameObject puck;

    public Transform puckStart;

    public GameObject enemy;

    public Transform enemyStart;

    void OnTriggerExit(Collider other)
    {
        // TODO instead of destroying and re-instantiating, consider just moving the objects

        if (other.gameObject.CompareTag("Puck"))
        {
            Destroy(other.gameObject);
            Instantiate(puck, puckStart.position, puckStart.rotation);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Instantiate(enemy, enemyStart.position, enemyStart.rotation);
        }
    }
}