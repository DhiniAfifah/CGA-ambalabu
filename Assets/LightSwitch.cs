using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject onObj;
    public GameObject offObj;

    public GameObject lightText;

    public GameObject lightObj;

    public AudioSource switchClick;

    public bool lightsAreOn;
    public bool lightsAreOff;
    public bool inReach;


    // Start is called before the first frame update
    void Start()
    {
        inReach = false;
        lightsAreOn = false;
        lightsAreOff = true;
        onObj.SetActive(false);
        offObj.SetActive(true);
        lightObj.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            lightText.SetActive(true);
        }    
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            lightText.SetActive(false);
        }    
    }

    // Update is called once per frame
    void Update()
    {
        if (lightsAreOn && inReach && Input.GetButtonDown("Interact"))
        {
            lightObj.SetActive(false);
            onObj.SetActive(false);
            offObj.SetActive(true);
            switchClick.Play();
            lightsAreOff = true;
            lightsAreOn = false;
        } else if (lightsAreOff && inReach && Input.GetButtonDown("Interact"))
        {
            lightObj.SetActive(true);
            onObj.SetActive(true);
            offObj.SetActive(false);
            switchClick.Play();
            lightsAreOff = false;
            lightsAreOn = true;
        }
    }
}
