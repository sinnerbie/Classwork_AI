using UnityEngine.AI;
using UnityEngine;

public class AgentNavigation : MonoBehaviour
{
    [SerializeField] private Transform target;
    private NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < 1)
            agent.isStopped = true;
        else
            { agent.isStopped = false; agent.SetDestination(target.position); }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;

        if (target == null || agent == null) return;
        Vector3[] corners = agent.path.corners;

        for (int i = 0; i < corners.Length; i++)
            if (i != corners.Length - 1) Gizmos.DrawLine(corners[i], corners[i + 1]);
    }
}
