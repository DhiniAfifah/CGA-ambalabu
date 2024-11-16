using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameObject flashlightON;
    public GameObject flashlightOFF;
    public GameObject flashlightObj;

    public GameObject m4;
    public GameObject m4Obj;

    public GameObject glock;
    public GameObject glockObj;

    public GameObject knife;
    public GameObject knifeObj;

    public GameObject lighter;
    public GameObject lighterObj;

    // Start is called before the first frame update
    void Start()
    {
        flashlightON.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (flashlightObj.activeInHierarchy)
        {
            flashlightON.SetActive(true);
            flashlightOFF.SetActive(false);
        } else
        {
            flashlightON.SetActive(false);
            flashlightOFF.SetActive(true);
        }

        if (m4Obj.activeInHierarchy)
        {
            m4.SetActive(true);
        } else
        {
            m4.SetActive(false);
        }

        if (glockObj.activeInHierarchy)
        {
            glock.SetActive(true);
        } else
        {
            glock.SetActive(false);
        }

        if (knifeObj.activeInHierarchy)
        {
            knife.SetActive(true);
        } else
        {
            knife.SetActive(false);
        }
       
    }
}
