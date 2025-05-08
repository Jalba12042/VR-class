using System.Collections;
using UnityEngine;

public class ObjectBounce : MonoBehaviour
{
    public float bounceSpeed = 8f;
    public float bounceAmplitude = 0.05f;
    public float rotationSpeed = 90f;
    public float bounceDuration = 2f; // Duration of bounce in seconds

    private float startHeight;
    private float timeOffset;
    private bool isBouncing = false;
    private float bounceTimer = 0f;

    void Start()
    {
        startHeight = transform.localPosition.y;
        timeOffset = Random.value * Mathf.PI * 2;
    }

    void Update()
    {
        if (isBouncing)
        {
            bounceTimer += Time.deltaTime;

            float finalHeight = startHeight + Mathf.Sin(Time.time * bounceSpeed + timeOffset) * bounceAmplitude;
            var position = transform.localPosition;
            position.y = finalHeight;
            transform.localPosition = position;

            Vector3 rotation = transform.localRotation.eulerAngles;
            rotation.y += rotationSpeed * Time.deltaTime;
            transform.localRotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);

            if (bounceTimer >= bounceDuration)
            {
                isBouncing = false;
                bounceTimer = 0f;
                // Reset Y to original position
                var pos = transform.localPosition;
                pos.y = startHeight;
                transform.localPosition = pos;
            }
        }
    }

    // Call this from your UI button
    public void StartBounce()
    {
        isBouncing = true;
        bounceTimer = 0f;
    }
}
