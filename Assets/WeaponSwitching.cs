using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public List<GameObject> objects; // List to store weapon objects (exclude "hands")

    // Start is called before the first frame update
    void Start()
    {
        // Ensure all objects are inactive at the start
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for key presses dynamically
        for (int i = 0; i <= objects.Count; i++)
        {
            if (Input.GetButtonDown((i + 1).ToString()))
            {
                SwitchObject(i);
            }
        }
    }

    void SwitchObject(int index)
    {
        // If index is 0, represent "hands" (no weapon)
        if (index == 0)
        {
            foreach (GameObject obj in objects)
            {
                obj.SetActive(false); // Deactivate all objects
            }
        }
        else
        {
            // Disable all objects, then activate the selected one
            for (int i = 0; i < objects.Count; i++)
            {
                objects[i].SetActive(i == index - 1); // Adjust index (1-based input vs 0-based list)
            }
        }
    }
}
