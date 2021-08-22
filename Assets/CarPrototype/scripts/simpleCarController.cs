using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simpleCarController : MonoBehaviour
{
    internal enum driveType
    {
        frontWheelDrive,
        rearWheelDrive,
        allWheelDrive
    }
    [SerializeField] private driveType drive;

    [Header("Variables")]
    [Range(5, 20)] public float DownForceValue;
    [Range(0.01f, 0.02f)] public float dragAmount;
    [HideInInspector] public float ForwardStifness;
    [HideInInspector] public float SidewaysStifness;
    [HideInInspector] public float KPH;//КМ/Ч


    public WheelCollider[] wheels;//колеса
    public float motorPower = 100;// сила мотора
    public float steerPower = 100;//угол поворота
    public float rushPower = 5; //сила накопительного удара удар

    [SerializeField] Material brakeLights;
    Rigidbody rBody;
    public GameObject centreOfMass;

    private float radius = 0.7f;
    private float[] wheelSlip;
    private WheelFrictionCurve forwardFriction, sidewaysFriction;
    private float curRushPower;
    private float brakPower;
    private float vertical;
    private float downforce;    
    private float totalPower;
    private  inputManager IM;

    private bool reverse = false;
    private bool grounded;
    private bool lightsFlag;

    // Start is called before the first frame update
    void Start()
    {
        IM = GetComponent<inputManager>();
        rBody = GetComponent<Rigidbody>();
        rBody.centerOfMass = centreOfMass.transform.localPosition;
        wheelSlip = new float[wheels.Length];
    }

    private void FixedUpdate()
    {
        moveVehicle();
        activateLights();
    }

    void Update()
    {
        addDownForce();
        //friction();
        if (IM.boosting)
        {
            AddRushForce(rushPower);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Rush(curRushPower);
            curRushPower = rushPower;
        }
    }

    //private void friction()
    //{

    //    WheelHit hit;
    //    float sum = 0;
    //    float[] sidewaysSlip = new float[wheels.Length];
    //    for (int i = 0; i < wheels.Length; i++)
    //    {
    //        if (wheels[i].GetGroundHit(out hit) && i >= 2)
    //        {
    //            forwardFriction = wheels[i].forwardFriction;
    //            forwardFriction.stiffness = (IM.handbrake) ? .55f : ForwardStifness;
    //            wheels[i].forwardFriction = forwardFriction;

    //            sidewaysFriction = wheels[i].sidewaysFriction;
    //            sidewaysFriction.stiffness = (IM.handbrake) ? .55f : SidewaysStifness;
    //            wheels[i].sidewaysFriction = sidewaysFriction;

    //            grounded = true;

    //            sum += Mathf.Abs(hit.sidewaysSlip);

    //        }
    //        else grounded = false;

    //        wheelSlip[i] = Mathf.Abs(hit.forwardSlip) + Mathf.Abs(hit.sidewaysSlip);
    //        sidewaysSlip[i] = Mathf.Abs(hit.sidewaysSlip);


    //    }

    //    sum /= wheels.Length - 2;
    //    radius = (KPH > 60) ? 4 + (sum * -25) + KPH / 8 : 4;

    //}

    private void moveVehicle()
    {
        foreach (var wheel in wheels)
        {
            wheel.motorTorque = IM.vertical * ((motorPower * 50) / 4);
        }
        for (int i = 0; i < wheels.Length; i++)
        {
            if (i < 2)
            {
                wheels[i].steerAngle = IM.horizontal * steerPower;
            }

        }
        for (int i = 0; i < wheels.Length; i++)
        {
            if (KPH <= 1 && KPH >= -1 && IM.vertical ==0)
            {
                brakPower = 10;
            }
            if (IM.handbrake)
            {
                brakPower = 10;
            }
            else
            {
                brakPower = 0;
            }
            wheels[i].brakeTorque = brakPower;
        }

        wheels[2].brakeTorque = wheels[3].brakeTorque = (IM.handbrake) ? Mathf.Infinity : 0f;

        rBody.angularDrag = (KPH > 100) ? KPH / 100 : 0;

        rBody.drag = dragAmount + (KPH / 40000);

        KPH = rBody.velocity.magnitude * 3.6f;
    }


    // Update is called once per frame

    private void Rush(float rPower)
    {
        rBody.AddForce(new Vector3 (0, 0, rPower).normalized, ForceMode.Acceleration);
        print("Rush");
    }

    private void AddRushForce(float rPower)
    {
        if (curRushPower >= 1000) curRushPower = 1000;
        else curRushPower += rPower;


        print(curRushPower);
    }

    //public bool isGrounded()
    //{
    //    if (wheels[0].isGrounded && wheels[1].isGrounded && wheels[2].isGrounded && wheels[3].isGrounded)
    //        return true;
    //    else
    //        return false;
    //}
    private void activateLights()
    {
        if (IM.vertical < 0 || KPH <= 1)
        { turnLightsOn(); }
        else turnLightsOff();
    }

    private void turnLightsOn()
    {
        if (lightsFlag) return;
        brakeLights.SetColor("_EmissionColor", new Color(255f, 35f, 35f) * 0.115f);
        lightsFlag = true;
    }

    private void turnLightsOff()
    {
        if (!lightsFlag) return;
        brakeLights.SetColor("_EmissionColor", Color.black);
        lightsFlag = false;
    }


    private void addDownForce()
    {
        downforce = Mathf.Abs(DownForceValue * rBody.velocity.magnitude);
        downforce = KPH > 60 ? downforce : 0;
        rBody.AddForce(-transform.up * downforce);    
    }
}
