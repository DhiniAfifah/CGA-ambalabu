using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScMovement : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 7f;
    [SerializeField] bool isGrounded;

    public Transform cameraTransform;
    public float rotationSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Vector3 moveDirection = (forward * v + right * h).normalized * speed * Time.deltaTime;
        transform.Translate(moveDirection, Space.World);

        if (moveDirection != Vector3.zero)
        {
            Quaternion targetRotation;
            if (v >= 0)
            {
                targetRotation = Quaternion.LookRotation(moveDirection);
            }
            else
            {
                targetRotation = Quaternion.LookRotation(-moveDirection); 
            }

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("run", true);
        } else
        {
            anim.SetBool("run", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("runBack", true);
        } else
        {
             anim.SetBool("runBack", false);
        }

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            anim.SetBool("lompat", true);

            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        } else
        {
            anim.SetBool("lompat", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("tanah"))
        {
            isGrounded = true;
        }
    }
}
