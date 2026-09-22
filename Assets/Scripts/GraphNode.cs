using UnityEngine;
using System.Collections.Generic;

public class GraphNode : MonoBehaviour
{
    public string nodeName;
    public List<GraphEdge> edges = new List<GraphEdge>();

    void Start()
    {
        nodeName = gameObject.name;
    }

    private void OnDrawGizmos()
    {
        foreach (GraphEdge e in edges)
        {
            if (e.destination != null)
                Gizmos.DrawLine(transform.position, e.destination.transform.position);
        }
    }
}
