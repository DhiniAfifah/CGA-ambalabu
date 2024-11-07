using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScCamera : MonoBehaviour
{
    public float turnSpeed = 4.0f;
    public float pitchMin = -30f;
    public float pitchMax = 60f;

    private Transform posHero;
    private Vector3 thirdPersonOffset;
    private Vector3 firstPersonOffset;

    [Header("View Settings")]
    public bool isFirstPerson = false; // Toggle in Inspector for view mode

    private float pitch = 0.0f;
    private float yaw = 0.0f;

    void Start()
    {
        posHero = GameObject.Find("jono").transform;

        // Offsets for third and first person views
        thirdPersonOffset = new Vector3(1f, 2.5f, -3f);
        firstPersonOffset = new Vector3(0f, 0.8f, 0f); // Adjust as needed for first-person view
    }

    void Update()
    {
        // Toggle view mode with "C" key, as well as via Inspector
        if (Input.GetKeyDown(KeyCode.C))
        {
            isFirstPerson = !isFirstPerson;
        }

        yaw += Input.GetAxis("Mouse X") * turnSpeed;
        pitch -= Input.GetAxis("Mouse Y") * turnSpeed;
        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);

        if (isFirstPerson)
        {
            // First-person view
            transform.position = posHero.position + firstPersonOffset;
            transform.rotation = Quaternion.Euler(pitch, yaw, 0);
        }
        else
        {
            // Third-person view
            Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
            transform.position = posHero.position + rotation * thirdPersonOffset;
            transform.LookAt(posHero.position);
        }
    }
}
