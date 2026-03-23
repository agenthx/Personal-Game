using UnityEngine;

public class PlayerCasting : MonoBehaviour
{
    public static float distanceToInteract;
    [SerializeField] private float interactRange;
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            interactRange = hit.distance;
            distanceToInteract = interactRange;
        }
    }
}
