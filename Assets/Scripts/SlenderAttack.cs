using UnityEngine;
using UnityEngine.SceneManagement; // for restarting scene

public class SlenderAttack : MonoBehaviour
{
    private bool hasAttacked = false; // to prevent multiple attacks
    public float attackRange = 2f; // how close he needs to be
    public Animator animator;      // Slender�s Animator
    public Transform player;       // assign Player in Inspector

    private UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        if (hasAttacked) return; // already attacked, do nothing
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            agent.isStopped = true; // stop moving
            animator.SetTrigger("Attack"); // play attack animation
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        // Restart scene after short delay
        Invoke("RestartGame", 2f); // wait for animation to finish
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
