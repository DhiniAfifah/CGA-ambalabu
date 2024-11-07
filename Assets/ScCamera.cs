using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScCamera : MonoBehaviour
{
    public float turnSpeed = 4.0f;
    private Transform posHero;
    private Vector3 offset;
    private float pitch = 0.0f;
    private float yaw = 0.0f;

    public float pitchMin = -30f;
    public float pitchMax = 60f;

    // Start is called before the first frame update
    void Start()
    {
        posHero = GameObject.Find("jono").transform;
        offset = new Vector3(1f, 2.5f, -3f);
    }

    // Update is called once per frame
    void Update()
    {
        yaw += Input.GetAxis("Mouse X") * turnSpeed;
        pitch -= Input.GetAxis("Mouse Y") * turnSpeed;

        pitch = Mathf.Clamp(pitch, pitchMin, pitchMax);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        transform.position = posHero.position + rotation * offset;

        transform.LookAt(posHero.position);
    }
}
