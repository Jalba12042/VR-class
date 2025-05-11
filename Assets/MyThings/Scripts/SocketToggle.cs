using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ToggleGameObjectsOnSocket : MonoBehaviour
{
    public XRSocketInteractor socketInteractor;         // Assign in Inspector
    public string requiredTag = "Key";                  // The tag the object must have to trigger the toggle

    [Header("GameObjects to Enable/Show")]
    public GameObject[] objectsToEnable;

    [Header("GameObjects to Disable/Hide")]
    public GameObject[] objectsToDisable;


    private void OnEnable()
    {
        socketInteractor.selectEntered.AddListener(OnObjectPlaced);
    }

    private void OnDisable()
    {
        socketInteractor.selectEntered.RemoveListener(OnObjectPlaced);
    }

    private void OnObjectPlaced(SelectEnterEventArgs args)
    {

        GameObject placedObject = args.interactableObject.transform.gameObject;
        if (placedObject.CompareTag(requiredTag))
        {
            Debug.Log($"Correct object placed in socket: {placedObject.name}. Toggling GameObjects.");

            foreach (GameObject go in objectsToEnable)
                if (go != null) go.SetActive(true);

            foreach (GameObject go in objectsToDisable)
                if (go != null) go.SetActive(false);
        }
        else
        {
            Debug.Log($"Wrong object placed in socket: {placedObject.name}");
        }
    }
}
