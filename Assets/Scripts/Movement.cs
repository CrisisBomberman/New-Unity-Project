using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    AudioSource aS;
    [SerializeField] float RotationAmount = 100f;
    [SerializeField] float ThrustAmount = 100f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }


    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotationMethod(RotationAmount);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotationMethod(-RotationAmount);
        }
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * ThrustAmount * Time.deltaTime);
            if (!aS.isPlaying)
            {
                aS.Play();
            }
        }
        else
                aS.Stop();


    }
    void RotationMethod(float rotationThisFrame)
    {
        rb.freezeRotation = true;//Freezing rotation so we can manually rotation
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;//unFreezing rotation so physics system can take over
    }
}
