using UnityEngine;

public class Door : MonoBehaviour
{
    public string KeyName;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Door collided with " + collision.gameObject.name);
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();
        Debug.Log("PlayerMovement component: " + (player != null ? "found" : "not found"));
        if (player == null) return;

        Debug.Log("Player owns key: " + player.OwnKey(KeyName));

        if (player.OwnKey(KeyName))
        {
            Destroy(gameObject);
        }
    }
}