using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Ladder : MonoBehaviour
{
    public Transform playerController;
    bool inside = false;
    public float speed = 3f;
    public FirstPersonController player;
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<FirstPersonController>();
        inside = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            /*Debug.Log("Kena ladder cuk");*/
            player.enabled = false;
            inside = !inside;
        }    
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            /*Debug.Log("GA Kena ladder cuk");*/
            player.enabled = true;
            inside = !inside;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (inside == true && Input.GetKey("w"))
        {
            player.transform.position += Vector3.up / speed * Time.deltaTime;
        }

        if (inside == true && Input.GetKey("s"))
        {
            player.transform.position += Vector3.down / speed * Time.deltaTime;
        }

        if (inside == true && Input.GetKey("w"))
        {
            sound.enabled = true;
            sound.loop = true;
        } else
        {
            sound.enabled = false;
            sound.loop = false;
        }
    }
}
