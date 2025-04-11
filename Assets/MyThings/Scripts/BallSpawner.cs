using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;  // Assign ball prefab in Inspector
    public Transform spawnPoint;   // Hand/controller where the ball appears
    public InputActionReference selectAction;  // Select button from XRI input system
    public XRInteractionManager interactionManager; // Scene's XRI Interaction Manager
    public XRGrabInteractable grabTemplate; // Preconfigured grab settings (optional)

    private void OnEnable()
    {
        selectAction.action.performed += SpawnBall;
    }

    private void OnDisable()
    {
        selectAction.action.performed -= SpawnBall;
    }

    private void SpawnBall(InputAction.CallbackContext context)
    {
        if (ballPrefab == null || spawnPoint == null || interactionManager == null)
            return;

        // Spawn ball at hand position
        GameObject newBall = Instantiate(ballPrefab, spawnPoint.position, spawnPoint.rotation);

        // Add and configure XRGrabInteractable if not already on the prefab
        XRGrabInteractable grabComponent = newBall.GetComponent<XRGrabInteractable>();
        if (grabComponent == null)
        {
            grabComponent = newBall.AddComponent<XRGrabInteractable>();
        }

        // If a grab template exists, copy its settings (optional)
        if (grabTemplate != null)
        {
            grabComponent.interactionLayers = grabTemplate.interactionLayers;
            grabComponent.movementType = grabTemplate.movementType;
            grabComponent.trackPosition = grabTemplate.trackPosition;
            grabComponent.trackRotation = grabTemplate.trackRotation;
        }

        // Auto-select (grab) the ball using the new interaction system
        IXRSelectInteractor interactor = spawnPoint.GetComponentInParent<IXRSelectInteractor>();
        if (interactor != null)
        {
            interactionManager.SelectEnter(interactor, grabComponent);
        }
    }
}
