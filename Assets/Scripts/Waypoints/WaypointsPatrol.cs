using UnityEngine;

public class WaypointsPatrol : MonoBehaviour
{
    [SerializeField] private WaypointGraph wyptGraph;

    [Header("Movement")]
    [SerializeField] private float speed = 5;
    [SerializeField] private float targetThreshhold = 0.2f;
    [SerializeField] private float rotSpeed = 5;

    public int currentWypt = 0;

    private int wyptDirection = 1;

    public bool recycleWaypoints = false;

    void Update()
    {
        if (wyptGraph == null || wyptGraph.waypoints.Length == 0)
            return;

        Vector3 target = wyptGraph.GetPosition(currentWypt);

        // Find proximity
        Vector3 direction = target - transform.position;

        if (direction.magnitude <= targetThreshhold)
        {
            if (!recycleWaypoints)
                NextWaypoint();
            else
                RecycleWaypoint();
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
    }

    void NextWaypoint()
    {
        currentWypt = (currentWypt + 1) % wyptGraph.waypoints.Length;
    }

    void RecycleWaypoint()
    {
        if (currentWypt == wyptGraph.waypoints.Length - 1 || (currentWypt == 0 && wyptDirection == -1))
            wyptDirection *= -1;

        currentWypt += wyptDirection;
    }
}
