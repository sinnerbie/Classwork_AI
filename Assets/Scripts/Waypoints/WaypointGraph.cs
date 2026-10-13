using UnityEngine;

public class WaypointGraph : MonoBehaviour
{
    [SerializeField] public Transform[] waypoints;

    public Vector3 GetPosition(int index)
    {
        return waypoints[index].position;
    }

    private void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Length == 0) 
            return;

        Gizmos.color = Color.yellow;

        for (int i = 0; i < waypoints.Length; i++)
        {
            int next = (i + 1) % waypoints.Length;

            if (waypoints[next] != null)
                Gizmos.DrawLine(waypoints[i].position, waypoints[next].position);
        }
    }
}
