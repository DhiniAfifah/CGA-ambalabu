using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsWithLock : MonoBehaviour
{
    public Animator door;
    public GameObject openText;
    public GameObject keyInv;

    public AudioSource doorSound;
    public AudioSource lockedSound;

    public bool inReach;
    public bool unlocked;
    public bool locked;
    public bool hasKey;

    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        hasKey = false;
        unlocked = false;
        locked = true;
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
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (keyInv.activeInHierarchy)
        {
            locked = false;
            hasKey = true;
        } else
        {
            hasKey = false;
        }

        if (hasKey && inReach && Input.GetButtonDown("Interact"))
        {
            unlocked = true;
            DoorOpens();
        } else
        {
            DoorCloses();
        }

        if (locked && inReach && Input.GetButtonDown("Interact"))
        {
            lockedSound.Play();
        }
    }

    void DoorOpens()
    {
        /*Debug.Log("Kebuka pintunya");*/
        door.SetBool("open", true);
        door.SetBool("closed", false);
        doorSound.Play();
    }

    void DoorCloses()
    {
        /*Debug.Log("Ketutup pintunya");*/
        door.SetBool("open", false);
        door.SetBool("closed", true);
    }
}
