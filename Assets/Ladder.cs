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
            player.enabled = false;
            inside = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            player.enabled = true;
            inside = false;

            // Stop sound when leaving the ladder
            if (sound.isPlaying)
            {
                sound.Stop();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inside && Input.GetKey("w"))
        {
            player.transform.position += Vector3.up / speed * Time.deltaTime;

            // Play the sound if not already playing
            if (!sound.isPlaying)
            {
                sound.loop = true;
                sound.Play();
            }
        }
        else if (inside && Input.GetKey("s"))
        {
            player.transform.position += Vector3.down / speed * Time.deltaTime;

            // Play the sound if not already playing
            if (!sound.isPlaying)
            {
                sound.loop = true;
                sound.Play();
            }
        }
        else
        {
            // Stop the sound when not climbing
            if (sound.isPlaying)
            {
                sound.loop = false;
                sound.Stop();
            }
        }
    }
}
