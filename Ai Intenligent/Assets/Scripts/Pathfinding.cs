using Priority_Queue;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    // <>
    public Waypoint[] waypoints;

    public Waypoint start;
    public Waypoint goal;

    public void Start()
    {
        List<Waypoint> path = FindPath(start, goal);
        foreach (Waypoint wp in path)
        {
            Debug.Log(wp.gameObject.name);
        }
    }

    private float Heuristic(Waypoint wp, Waypoint goal)
    {
        return Vector3.Distance(wp.transform.position, goal.transform.position);
    }

    private List<Waypoint> ReconstructPath(Dictionary<Waypoint, Waypoint> cameFrom, Waypoint current, Waypoint start)
    {
        List<Waypoint> path = new List<Waypoint>();
        path.Add(current);
        while (current != start)
        {
            foreach (Waypoint wp in cameFrom.Keys)
            {
                if (wp == current)
                {
                    current = cameFrom[wp];
                    path.Add(current);
                }
            }
        }
        path.Reverse();
        return path;
    }


    public List<Waypoint> FindPath(Waypoint start, Waypoint goal)
    {
        List<Waypoint> closedSet = new List<Waypoint>();
        SimplePriorityQueue<Waypoint> openSet = new SimplePriorityQueue<Waypoint>();
        openSet.Enqueue(start, Heuristic(start, goal));

        Dictionary<Waypoint, Waypoint> cameFrom = new Dictionary<Waypoint, Waypoint>();
        Dictionary<Waypoint, float> gScore = new Dictionary<Waypoint, float>();
        foreach (Waypoint wp in waypoints)
        {
            gScore.Add(wp, Mathf.Infinity);
        }
        gScore[start] = 0;

        while (openSet.Count > 0)
        {
            Waypoint current = openSet.Dequeue();
            if (current == goal)
            {
                return ReconstructPath(cameFrom, current, start);
            }
            closedSet.Add(current);
            foreach (Waypoint neighbor in current.edges)
            {
                if (closedSet.Contains(neighbor))
                {
                    continue;
                }
                if (!openSet.Contains(neighbor))
                {
                    openSet.Enqueue(neighbor, gScore[neighbor] + Heuristic(neighbor, goal));
                }

                float tentativeGScore = gScore[current] + Heuristic(current, neighbor);

                if (tentativeGScore >= gScore[neighbor])
                {
                    continue;
                }
                cameFrom[neighbor] = current;
                gScore[neighbor] = tentativeGScore;
                openSet.UpdatePriority(neighbor, gScore[neighbor] + Heuristic(neighbor, goal));
            }
        }
        return new List<Waypoint>();

    }
}
