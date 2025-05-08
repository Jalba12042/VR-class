using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class SceneSwapOnSocket : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socketInteractor;         // Assign in Inspector
    public string requiredTag = "Key";                  // Tag the object you want to detect
    public string sceneToLoad = "NextScene";            // Set the name of the scene to load

    private bool hasSwitched = false;

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
        if (hasSwitched) return;

        GameObject placedObject = args.interactableObject.transform.gameObject;
        if (placedObject.CompareTag(requiredTag))
        {
            Debug.Log($"Correct object placed in socket: {placedObject.name}. Loading scene: {sceneToLoad}");
            hasSwitched = true;
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.Log($"Wrong object placed in socket: {placedObject.name}");
        }
    }
}
