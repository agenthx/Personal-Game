using UnityEngine;
using UnityEngine.AI;

public class SlenderChase : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 10f;
    public float loseRange = 15f;
    public float wanderRadius = 15f;
    public float wanderTimer = 5f;

    private bool canChase;
    private NavMeshAgent agent;
    private Animator animator;
    private float timer;
    private bool isChasing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        timer = wanderTimer;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        // Detection logic
        if (!isChasing && distance <= detectionRange)
        {
            isChasing = true;
        }
        else if (isChasing && distance >= loseRange)
        {
            isChasing = false;
            timer = wanderTimer; // reset wander timer
        }

        if (isChasing && canChase)
        {
            // Chase player
            agent.speed = 3.5f; // run speed
            agent.SetDestination(player.position);

            animator.SetFloat("Speed", agent.velocity.magnitude); // drive Run anim
        }
        else
        {
            // Wander patrol
            agent.speed = 2.5f; // walk speed
            timer += Time.deltaTime;
            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavPosition(transform.position, wanderRadius, NavMesh.AllAreas);
                agent.SetDestination(newPos);
                timer = 0;
            }

            animator.SetFloat("Speed", agent.velocity.magnitude); // drive Walk anim
        }
    }

    Vector3 RandomNavPosition(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist + origin;
        if (NavMesh.SamplePosition(randDirection, out NavMeshHit navHit, dist, layermask))
        {
            return navHit.position;
        }
        return origin;
    }

    public void UnlockChase()
    {
        canChase = true;
        Debug.Log("chase activated!");
    }

}
