using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public string switchID; // "comet", "earth", "stars"
    private PuzzleLightManager manager;

    void Start()
    {
        manager = FindFirstObjectByType<PuzzleLightManager>();
    }

    public void FlipSwitch()
    {
        if (manager != null)
        {
            manager.OnSwitchFlipped(switchID);
        }
    }
}
