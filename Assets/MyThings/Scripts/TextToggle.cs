using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TextToggle : MonoBehaviour
{
    [Header("XR Interactable")]
    public XRSimpleInteractable interactable;

    [Header("Objects to Activate")]
    public GameObject[] objectsToActivate;

    [Header("Objects to Deactivate")]
    public GameObject[] objectsToDeactivate;

    private void OnEnable()
    {
        if (interactable != null)
        {
            interactable.selectEntered.AddListener(OnSelectEntered);
        }
    }

    private void OnDisable()
    {
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnSelectEntered);
        }
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        ToggleObjects();
    }

    private void ToggleObjects()
    {
        foreach (GameObject go in objectsToActivate)
            if (go != null) go.SetActive(true);

        foreach (GameObject go in objectsToDeactivate)
            if (go != null) go.SetActive(false);
    }
}
