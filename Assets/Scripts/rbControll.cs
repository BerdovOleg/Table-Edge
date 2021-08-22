using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rbControll : MonoBehaviour
{
    [SerializeField]inputManager IM;
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed;
    [SerializeField] private float brakeForce;
    [SerializeField] float rushPower;
    [SerializeField] private float steerPower;
    [SerializeField] private float drag;
    [SerializeField] float KHM;

    public GameObject[] wheelObjects;
    public WheelCollider[] wheels;
    public Transform CentreOfMass;


    private Vector3 wheelPosition;
    private Quaternion wheelRotation;

    // Start is called before the first frame update
    void Start()
    {
        rb.centerOfMass = CentreOfMass.localPosition;
    }

    private void FixedUpdate()
    {
        WheelsAnimated();

        ControlsCar();

        ReverseForce();

        BrakeControl();
    }

    private void WheelsAnimated()
    {
        for (int i = 0; i < wheels.Length; i++)
        {
            wheels[i].GetWorldPose(out wheelPosition, out wheelRotation);
            wheelObjects[i].transform.position = wheelPosition;
            wheelObjects[i].transform.rotation = wheelRotation;

        }
    }

    private void BrakeControl()
    {
        if (IM.handbrake)
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].brakeTorque = brakeForce;
            }
        }
        else
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].brakeTorque = 0;
            }
        }
    }

    private void ControlsCar()
    {
        foreach (var wheel in wheels)
        {
            wheel.motorTorque = IM.vertical * (speed / 4);
        }

        for (int i = 0; i < wheels.Length; i++)
        {
            if (i < 2)
            {
                wheels[i].steerAngle = IM.horizontal * steerPower;
            }

        }

        if (IM.vertical != 0)
        {
            Vector3 v3Force = 15 * transform.forward * IM.vertical;
            rb.AddForce(v3Force, ForceMode.Acceleration);
        }
    }


    private void ReverseForce()
    {
        if (IM.vertical > 0)
        {
            drag = (KHM / 100) * 0.5f;
            rb.drag = drag;
        }
        else
            rb.drag = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        KHM = Mathf.Round( rb.velocity.magnitude * 3.6f);
    }

    private void OnGUI()
    {
        GUI.TextField(new Rect(10, 10, 150, 30), KHM.ToString() + " - ÊÌ/×");
    }
}
