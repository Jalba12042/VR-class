using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    [SerializeField]
    private float tumble = 1f;

    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Vector3.zero; // Start stationary
    }

    // Call this from a UI button or other object
    public void StartRotation()
    {
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
