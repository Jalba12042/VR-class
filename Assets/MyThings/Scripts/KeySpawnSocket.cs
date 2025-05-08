using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeySpawnSocket : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket;
    public GameObject keyPrefab;
    public Transform spawnPoint;
    public string requiredObjectName = "Kettlebell";

    private bool hasSpawned = false;

    private void OnEnable()
    {
        socket.selectEntered.AddListener(OnObjectPlaced);
    }

    private void OnDisable()
    {
        socket.selectEntered.RemoveListener(OnObjectPlaced);
    }

    private void OnObjectPlaced(SelectEnterEventArgs args)
    {
        if (hasSpawned)
        {
            Debug.Log("Key already spawned.");
            return;
        }

        if (args.interactableObject.transform.name.Contains(requiredObjectName))
        {
            Debug.Log($"Kettlebell placed in socket: {args.interactableObject.transform.name}");

            // Optional: Hide the kettlebell instead of destroying
            args.interactableObject.transform.gameObject.SetActive(false);
            Debug.Log("Kettlebell set inactive.");

            // Spawn the key
            Instantiate(keyPrefab, spawnPoint.position, spawnPoint.rotation);
            Debug.Log("Key spawned at spawn point.");

            hasSpawned = true;
        }
        else
        {
            Debug.Log($"Wrong object placed: {args.interactableObject.transform.name}");
        }
    }
}
