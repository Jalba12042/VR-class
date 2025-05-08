using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadManager : MonoBehaviour
{
    public List<Toggle> toggles; // All 9 toggles on the keypad
    public List<int> correctDigits = new List<int> { 2, 5, 7, 9 }; // Your 4 correct numbers
    public GameObject objectToUnlock; // Optional, e.g., door

    void Update()
    {
        List<int> selected = new List<int>();

        for (int i = 0; i < toggles.Count; i++)
        {
            if (toggles[i].isOn)
            {
                selected.Add(i + 1); // Assuming toggle index + 1 = number label
            }
        }

        if (selected.Count == 4 && IsCorrectCombination(selected))
        {
            Debug.Log("Correct combination!");
            UnlockObject();
            // Optional: Disable this script if puzzle is one-time
            enabled = false;
        }
    }

    bool IsCorrectCombination(List<int> input)
    {
        foreach (int num in correctDigits)
        {
            if (!input.Contains(num))
                return false;
        }
        return true;
    }

    void UnlockObject()
    {
        if (objectToUnlock != null)
        {
            objectToUnlock.SetActive (true);
        }
    }
}
