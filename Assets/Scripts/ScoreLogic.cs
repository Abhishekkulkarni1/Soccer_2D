using UnityEngine;
using UnityEngine.Serialization;

public class ScoreLogic : MonoBehaviour
{
    public static int PlayerScore { get; private set; }
    public static int EnemyScore { get; private set; }
    public GameObject puck;

    public Transform puckStart;

    public bool playerGate;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Puck"))
        {
            Destroy(other.gameObject);
            Instantiate(puck, puckStart.position, puckStart.rotation);
            if (playerGate)
            {
                EnemyScore++;
                print("Enemy Score is " + EnemyScore);
            }
            else
            {
                PlayerScore++;
                print("Player Score is " + PlayerScore);
            }
        }
    }
}