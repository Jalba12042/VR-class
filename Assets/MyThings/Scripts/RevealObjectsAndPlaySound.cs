using UnityEngine;

public class RevealObjectsAndPlaySound : MonoBehaviour
{
    [SerializeField] private AudioSource soundEffectSource;
    [SerializeField] private GameObject[] objectsToReveal;

    // Call this from a UI button
    public void Activate()
    {
        // Play sound
        if (soundEffectSource != null)
        {
            soundEffectSource.Play();
        }

        // Make all target objects visible
        foreach (GameObject obj in objectsToReveal)
        {
            if (obj != null)
                obj.SetActive(true);
        }
    }
}
