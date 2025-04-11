using UnityEngine;

public class PuzzleLightManager : MonoBehaviour
{
    public GameObject cometLightObject;
    public GameObject earthLightObject;
    public Light mainRoomLight;
    public GameObject ceilingStarsAndCode; // stars + keypad numbers

    private bool starsActivated = false;

    public void OnSwitchFlipped(string switchID)
    {
        switch (switchID.ToLower())
        {
            case "comet":
                ToggleObject(cometLightObject);
                break;

            case "earth":
                ToggleObject(earthLightObject);
                break;

            case "stars":
                if (!starsActivated)
                    ActivateStars();
                break;
        }
    }

    void ToggleObject(GameObject obj)
    {
        if (obj != null)
            obj.SetActive(!obj.activeSelf);
    }

    void ActivateStars()
    {
        starsActivated = true;

        if (mainRoomLight != null)
            mainRoomLight.intensity = 0.1f; // or disable it

        if (ceilingStarsAndCode != null)
            ceilingStarsAndCode.SetActive(true);

        Debug.Log("Stars activated!");
    }
}
