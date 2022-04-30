using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Priority_Queue;

public class NPCMovement : MonoBehaviour
{
    public Pathfinding pathfinding;
    public Queue<Waypoint> movement;
    public Vector3 nextCurrentPosition;
    public bool isDone = false;

    void Start()
    {

        pathfinding.start = LocateNearWaypoint(transform.position);

        List<Waypoint> path = pathfinding.FindPath(pathfinding.start, pathfinding.goal);
        foreach (Waypoint wp in path)
        {
            //movement.Enqueue(wp);
        }

        nextCurrentPosition = pathfinding.start.transform.position;
        transform.position = nextCurrentPosition;

    }

    void Update()
    {
        if (!isDone)
        {
            if (Vector3.Distance(transform.position, nextCurrentPosition) < 0.1f)
            {
                if (movement.Count > 0)
                {
                    nextCurrentPosition = movement.Dequeue().transform.position;
                }
                else isDone = false;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, nextCurrentPosition,  2 * Time.deltaTime);
            }
        }
        Debug.Log("current: " + transform.position);
        Debug.Log("target: " + nextCurrentPosition);    
    }

    public Waypoint LocateNearWaypoint(Vector3 position)
    {
        float maxDistance = float.MaxValue;
        Waypoint nearestWaypoint = null;
        foreach (Waypoint waypoint in pathfinding.waypoints)
        {
            float distance = Vector3.Distance(position, waypoint.transform.position);
            if (distance < maxDistance)
            {
                if (!Physics.Raycast(new Ray(position, position - waypoint.transform.position), distance))
                {
                    maxDistance = distance;
                    nearestWaypoint = waypoint;
                }
            }
        }
        return nearestWaypoint;
    }
}
