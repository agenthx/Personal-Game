using UnityEngine;
using UnityEngine.AI;

public class SlenderAnimatorController : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Get agent velocity (how fast he's moving)
        float speed = agent.velocity.magnitude;

        // Update Animator parameter
        animator.SetFloat("Speed", speed);
    }
}
