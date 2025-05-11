using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportPlayerOnPress : MonoBehaviour
{
    public Transform playerRig;        // XR Origin or rig
    public Transform teleportTarget;   // Where to teleport

    public void TeleportPlayer()
    {
        if (playerRig != null && teleportTarget != null)
        {
            playerRig.position = teleportTarget.position;
            Debug.Log("Player teleported!");
        }
    }
}
