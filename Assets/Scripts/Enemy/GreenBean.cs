using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class GreenBean : MonoBehaviour
{
    [Header("References")]
    public Transform player;

    private NavMeshAgent agent;

    [Header("Vision")]
    public float viewDistance = 15f;
    public float viewAngle = 60f;
    public LayerMask obstacleMask;

    [Header("Movement")]
    public float followUpdateRate = 0.25f;
    public float wanderRadius = 10f;
    public float wanderTime = 4f;

    [Header("Speed")]
    public float wanderSpeed = 2f;
    public float followSpeed = 4f;
    public float speedLerp = 5f;

    [Header("Agent Feel")]
    public float acceleration = 6f;
    public float angularSpeed = 120f;

    private float followTimer;
    private float wanderTimer;
    private Vector3 wanderTarget;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.acceleration = acceleration;
        agent.angularSpeed = angularSpeed;
        agent.speed = wanderSpeed;
        agent.autoBraking = false;

        PickNewWanderPoint();
    }

    void Update()
    {
        if (PlayerInSight())
        {
            SetSpeed(followSpeed);
            FollowPlayerSmooth();
        }
        else
        {
            SetSpeed(wanderSpeed);
            Wander();
        }
    }

    bool PlayerInSight()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > viewDistance)
            return false;

        float angle = Vector3.Angle(transform.forward, directionToPlayer);
        if (angle > viewAngle * 0.5f)
            return false;

        if (Physics.Raycast(transform.position + Vector3.up, directionToPlayer, distance, obstacleMask))
            return false;

        return true;
    }

    void FollowPlayerSmooth()
    {
        followTimer -= Time.deltaTime;

        if (followTimer <= 0f)
        {
            agent.SetDestination(player.position);
            followTimer = followUpdateRate;
        }
    }

    void Wander()
    {
        wanderTimer -= Time.deltaTime;

        if (wanderTimer <= 0f || agent.remainingDistance < 1f)
        {
            PickNewWanderPoint();
        }
    }

    void PickNewWanderPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, wanderRadius, NavMesh.AllAreas))
        {
            wanderTarget = hit.position;
            agent.SetDestination(wanderTarget);
        }

        wanderTimer = wanderTime;
    }

    void SetSpeed(float targetSpeed)
    {
        agent.speed = Mathf.Lerp(agent.speed, targetSpeed, Time.deltaTime * speedLerp);
    }
}
