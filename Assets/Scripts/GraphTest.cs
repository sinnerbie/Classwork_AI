using System.Collections.Generic;
using UnityEngine;

public class GraphTest : MonoBehaviour
{
    [SerializeField] GraphManager manager;
    [SerializeField] GraphNode startNode;
    [SerializeField] GraphNode goalNode;

    void Start()
    {
        List<GraphNode> list = manager.RecoverPath(startNode, goalNode, manager.bfs(startNode));
        string message = "Path = ";
        for (int i = 0; i < list.Count; i++)
        {
            if (i < list.Count - 1)
                message += list[i].gameObject.name + " -> ";
            else
                message += list[i].gameObject.name;
        }
        Debug.Log(message);
    }
}
