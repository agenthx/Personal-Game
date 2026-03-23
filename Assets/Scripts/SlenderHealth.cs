using UnityEngine;

public class SlenderHealth : MonoBehaviour
{
    public float health = 100f;
    public GameObject youWinUI;

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        // Stop AI and destroy Slender Man
        Destroy(gameObject);
        youWinUI.SetActive(true);
        // Or play animation, disable scripts, etc.
        // GetComponent<Animator>().SetTrigger("Die");
    }
}
