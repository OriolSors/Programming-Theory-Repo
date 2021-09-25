using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Plane : Vehicle
{
    [SerializeField]
    private float horsePower;

    [SerializeField]
    private float turnSpeed;

    [SerializeField]
    private float forwardSpeed;

    private Vector3 turnRotationVector;

    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        year = 2021;

        // ABSTRACTION
        InitRb();
        StartingForce();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // ABSTRACTION
        CheckPlaneWheels();
        Move();
        ConstForward();
    }

    private void InitRb()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    private void StartingForce()
    {
        playerRb.AddForce(transform.forward * forwardSpeed, ForceMode.Impulse);
    }

    // POLYMORPHISM
    public override void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float forwardInput = Input.GetAxis("Vertical");

        if(forwardInput > 0)
        {
            playerRb.AddForce((transform.forward - transform.up) * horsePower * forwardInput * Time.fixedDeltaTime, ForceMode.Acceleration);
        }
        else
        {
            playerRb.AddForce((transform.forward + transform.up) * horsePower * -forwardInput * Time.fixedDeltaTime, ForceMode.Impulse);
        }

        transform.Rotate(transform.right * Time.deltaTime * turnSpeed * forwardInput);
        transform.Rotate(turnRotationVector * Time.deltaTime * turnSpeed * horizontalInput);
    }

    private void ConstForward()
    {
        transform.Translate(transform.forward * Time.fixedDeltaTime * forwardSpeed);
    }

    private void CheckPlaneWheels()
    {
        if (transform.position.y > 0.5)
        {
            turnRotationVector = -transform.forward;
        }
        else
        {
            turnRotationVector = transform.up;
        }
    }


}
