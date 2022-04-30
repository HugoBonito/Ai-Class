using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentNavMesh : MonoBehaviour
{
    public Transform target;
    public Transform[] waypoints;
    public Transform energyPoint;

    public GameObject bulletPreFab;
    public float shootTimeInterval = 1;
    private float shootTimer = 1;

    public float energy = 30;

    private int currentWaypointIndex;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void GoToNextWaypoint()
    {
        agent.SetDestination(waypoints[currentWaypointIndex].transform.position);
        currentWaypointIndex++;
        if (currentWaypointIndex >= waypoints.Length)
        {
            currentWaypointIndex = 0;
        }
    }

    public bool isAtDestination()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0)
                    return true;
            }
        }
        return false;
    }

    public void GoToTarget()
    {
        agent.SetDestination(target.position);
    }

    public void Stop()
    {
        agent.isStopped = true;
        agent.ResetPath();
    }

    public void Shoot()
    {
        shootTimer += Time.deltaTime;
        if (shootTimer >= shootTimeInterval)
        {
            shootTimer = 0;
            GameObject bullet = Instantiate(bulletPreFab, transform.position + transform.forward, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().velocity = Vector3.Normalize(target.position - transform.position) * 10;
            energy -= 5;
        }
    }

    public void Recover()
    {
        if(energy <= 0)
        {
            agent.SetDestination(energyPoint.transform.position);
        }

    }

    public void RecoverEnergy()
    {
        energy = 30;
        GoToNextWaypoint();
    }

    
}