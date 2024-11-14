using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBoxWithLoot : MonoBehaviour
{
    public Animator boxObj;
    public GameObject keyObjNeeded;
    public GameObject openText;
    public GameObject keyMissingText;
    public AudioSource openSound;

    public GameObject drop1;
    public GameObject drop2;
    public GameObject drop3;
    public GameObject drop4;
    public GameObject drop5;
    public GameObject drop6;

    public bool inReach;
    public bool isOpen;

    public int randomNumber;

    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(0, 5);
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

            if (randomNumber == 0)
            {
                drop1.SetActive(true);
            }
            if (randomNumber == 1)
            {
                drop2.SetActive(true);
            }
            if (randomNumber == 2)
            {
                drop3.SetActive(true);
            }
            if (randomNumber == 3)
            {
                drop4.SetActive(true);
            }
            if (randomNumber == 4)
            {
                drop5.SetActive(true);
            }
            if (randomNumber == 5)
            {
                drop6.SetActive(true);
            }

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
