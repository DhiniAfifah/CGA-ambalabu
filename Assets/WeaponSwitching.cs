using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour
{
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;

    // Start is called before the first frame update
    void Start()
    {
        obj1.SetActive(false);
        obj2.SetActive(false);
        obj3.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("1"))
        {
            obj1.SetActive(false);
            obj2.SetActive(false);
            obj3.SetActive(false);
        }

        if (Input.GetButtonDown("2"))
        {
            obj1.SetActive(true);
            obj2.SetActive(false);
            obj3.SetActive(false);
        }

        if (Input.GetButtonDown("3"))
        {
            obj1.SetActive(false);
            obj2.SetActive(true);
            obj3.SetActive(false);
        }

        if (Input.GetButtonDown("4"))
        {
            obj1.SetActive(false);
            obj2.SetActive(false);
            obj3.SetActive(true);
        }
    }
}
