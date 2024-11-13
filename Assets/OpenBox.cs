using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBox : MonoBehaviour
{
    public Animator boxObj;
    public GameObject keyObjNeeded;
    public GameObject openText;
    public GameObject keyMissingText;
    public AudioSource openSound;

    public bool inReach;
    public bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        openText.SetActive(false);
        keyMissingText.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }    
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
            keyMissingText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (keyObjNeeded.activeInHierarchy == true && inReach && Input.GetButtonDown("Interact"))
        {
            keyObjNeeded.SetActive(false);
            openSound.Play();
            boxObj.SetBool("open", true);
            openText.SetActive(false);
            keyMissingText.SetActive(false);
            isOpen = true;
        } else if (keyObjNeeded.activeInHierarchy == false && inReach && Input.GetButtonDown("Interact"))
        {
            openText.SetActive(false);
            keyMissingText.SetActive(true);
        }

        if (isOpen)
        {
            boxObj.GetComponent<BoxCollider>().enabled = false;
            boxObj.GetComponent<OpenBox>().enabled = false;
        }
    }
}
