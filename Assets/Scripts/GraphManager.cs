using System.Collections.Generic;
using UnityEngine;

public class GraphManager : MonoBehaviour
{
    public GraphNode[] nodes;

    public bool AreaAdjacent(GraphNode nodeA, GraphNode nodeB)
    {
        foreach (GraphEdge e in nodeA.edges)
            if (e.destination == nodeB) return true;
        return false;
    }

    public int GetOutDegree(GraphNode node)
    {
        return node.edges.Count;
    }

    public int GetInDegree(GraphNode node)
    {
        int degree = 0;
        foreach (GraphNode e in nodes)
        {
            foreach (GraphEdge a in e.edges)
                if (a.destination == node) degree++;
        }
        return degree;
    }

    public float GetEdgeCost(GraphNode nodeA, GraphNode nodeB)
    {
        foreach (GraphEdge e in nodeA.edges)
            if (e.destination == nodeB) return e.weight;
        return -1;
    }

    public float CalculatePathCost(GraphNode[] path)
    {
        float cost = 0;
        for (int i = 0; i < path.Length - 1; i++)
        {
            cost += GetEdgeCost(path[i], path[i + 1]);
        }
        return cost;
    }

    public bool IsCycle(GraphNode[] path)
    {
        return false;
    }

    #region Algorithms
    public Dictionary<GraphNode, GraphNode> bfs(GraphNode start)
    {
        // Queue to process nodes
        Queue<GraphNode> queue = new Queue<GraphNode>();
        // Set to store visited nodes
        HashSet<GraphNode> visited = new HashSet<GraphNode>();
        Dictionary<GraphNode, GraphNode> predecessor = new Dictionary<GraphNode, GraphNode>();

        // Start algorithm
        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Count > 0)
        {
            GraphNode currentNode = queue.Dequeue();

            foreach(GraphEdge e in currentNode.edges)
            {
                GraphNode next = e.destination;
                if (!visited.Contains(next))
                {
                    queue.Enqueue(next);
                    visited.Add(next);
                    predecessor[next] = currentNode;
                }
            }
        }

        return predecessor;
    }

    public List<GraphNode> RecoverPath(GraphNode start, GraphNode goal, Dictionary<GraphNode, GraphNode> predecessor)
    {
        List<GraphNode> path = new List<GraphNode>();

        GraphNode current = goal;

        path.Add(current);

        while (current != start)
        {
            current = predecessor[current];
            path.Add(current);
        }

        path.Reverse();
        return path;
    }
    #endregion

    #region Notes
    // BFS = Breadth First Search, travels to all vertices connected to a given source to find the path with the leas edges
    // FIFO = First In First Out in a queue
    /* DFS = Depth First Search, travels to all vertices connected to a given source in depth, goes to the end of any path and checks
     alternate routes retroactivly */
    // LIFO(stack) = Last In First Out, 
    #endregion
}
