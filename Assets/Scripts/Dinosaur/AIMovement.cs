using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    [SerializeField]
    GameObject player, detectField;
    NavMeshAgent agent;

    bool detectedPlayer;
    public bool DetectedPlayer { get => detectedPlayer; set => detectedPlayer = value; }

    private void Update()
    {
        if (!DetectedPlayer)
        {
            agent.destination = detectField.transform.position;

            if (agent.remainingDistance < agent.stoppingDistance)
                DetectedPlayer = true;
        }

        else
        {
            agent.destination = player.transform.position;
        }
    }

    public void ResetAI()
    {
        DetectedPlayer = false;
        agent = GetComponent<NavMeshAgent>();
        agent.ResetPath();
        player = GameObject.FindGameObjectWithTag("Player");
        detectField = GameObject.Find("DetectField");
        agent.SetDestination(detectField.transform.position);
        
    }

    private void OnEnable() => ResetAI();
}
