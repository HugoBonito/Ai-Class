using UnityEngine;
using UnityEngine.AI;

public class MyNavMeshAgent : MonoBehaviour
{
    public Transform[] Waypoints;
    private int index;
    private NavMeshAgent agent;

    public Transform target;
    public float viewAngle;
    public float viewDistance;

    public GameObject bulletPreFab;
    public float shootTimeInterval = 1;
    private float shootTimer = 1;


    private enum State
    { PATROL, CHASE, ATTACK };

    private State myState;

    private void Start()
    {
        myState = State.PATROL;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(Waypoints[0].position);
    }

    private void Update()
    {
        if (myState == State.PATROL)
        {
            Patrol();

            if (canSeePlayer())
                myState = State.CHASE;
        }
        else if (myState == State.CHASE)
        {
            ChaseTarget();

            if (canSeePlayer() && isOnRange())
                myState = State.ATTACK;

            if (!canSeePlayer())
                myState = State.PATROL;
        }
        else if (myState == State.ATTACK)
        {
            Shoot();
            Stop();

            if (!isOnRange())
                myState = State.CHASE;
        }

        Debug.Log(myState);
    }

    private void Patrol()
    {
        {
            if (isAtDestination(agent))
            {
                index = Random.Range(0, Waypoints.Length);
                agent.SetDestination(Waypoints[index].position);
            }
        }
    }

    public void Stop()
    {
        agent.isStopped = true;
        agent.ResetPath();
    }

    public void ChaseTarget()
    {
        agent.SetDestination(target.position);
    }

    private bool canSeePlayer()
    {
        Vector3 direction = target.position - agent.transform.position;
        float distance = direction.magnitude;
        float angle = Vector3.Angle(direction.normalized, agent.transform.forward);
        if ((angle < viewAngle) && (distance < viewDistance))
        {
            return true;
        }
        return false;
    }

    private bool isOnRange()
    {
        Vector3 direction = target.position - agent.transform.position;
        float distance = direction.magnitude;
        if ((distance < viewDistance - 3))
        {
            return true;
        }
        return false;
    }

    public void Shoot()
    {
        if (isOnRange() == true)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootTimeInterval)
            {
                shootTimer = 0;
                GameObject bullet = Instantiate(bulletPreFab, transform.position + transform.forward, Quaternion.identity);
                bullet.GetComponent<Rigidbody>().velocity = Vector3.Normalize(target.position - transform.position) * 10;
            }
        }
    }

    private bool isAtDestination(NavMeshAgent a)
    {
        if (!a.pathPending)
        {
            if (a.remainingDistance <= a.stoppingDistance)
            {
                if (!a.hasPath || a.velocity.sqrMagnitude == 0)
                    return true;
            }
        }
        return false;
    }
}