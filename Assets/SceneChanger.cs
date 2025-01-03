using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class SceneChanger : MonoBehaviour
{
    public string sceneToLoad; // Name of the scene to load
    public GameObject pickupText; // Text shown when near the object
    private bool inReach = false; // If the player is near the interactable object

    void Start()
    {
        pickupText.SetActive(false); // Hide pickup text at the start
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Reach")) // Check if the player is near
        {
            inReach = true;
            pickupText.SetActive(true); // Show pickup text
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Reach")) // Check if the player leaves
        {
            inReach = false;
            pickupText.SetActive(false); // Hide pickup text
        }
    }

    void Update()
    {
        if (inReach && Input.GetButtonDown("Interact")) // Check if the player presses interact
        {
            pickupText.SetActive(true); // Show open text
            SceneManager.LoadScene(sceneToLoad); // Change the scene
        }
    }
}
