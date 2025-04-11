using UnityEngine;

public class BallDespawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor")) // Make sure your floor is tagged as "Floor"
        {
            Destroy(gameObject);
        }
    }
}
