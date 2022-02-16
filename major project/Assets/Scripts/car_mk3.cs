using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_mk3 : MonoBehaviour
{
    internal enum drivetype
    {
            frontwheel,
            rearwheel,
            allwheel
    }
  [SerializeField]  private drivetype drive;
    
    public AnimationCurve enginetorque;
    // public float wheelsrpm;
    public float handbreakfriction = 0;
    public float handbreakfrictionmultiplyer = 2f;
  
    private input_manager IM;
    public WheelCollider[] wheels = new WheelCollider[4];
    public GameObject[] wheelmesh = new GameObject[4];
    private Rigidbody rigid;
    public float KPH;
    private float tempo;

    public float totalpower;
    public float turnradius = 6;
    public float downforce = 50;
  //  public float steeringmax = 4;
    public float breakpower;
    private WheelFrictionCurve forwardfriction, sidewaysfriction;
    public float[] slip = new float[4];
    void Start()
    {
        getobjects();
    }

    private void FixedUpdate()
    {
        adddownforce();
        animatewheels();
        movevehicle();
        steering();
        getfriction();
        //   adjustfriction();
        // checkwheelspin();
        drift();
     //   Calculateenginepower();
    }
  //  private void Calculateenginepower()
    //{
     //   wheelrpm();
    //    totalpower = enginetorque.Evaluate(engineRPM) * (gears[gearNUM]) * IM.vertical;
    //        float velocity = 0.0f;
    //    engineRPM = Mathf.SmoothDamp(engineRPM, 1000 + (Mathf.Abs(wheelsrpm) * (gears[gearsNum])), ref velocity, smoothTime);
  //  }
  //  private void wheelrpm()
  //  {
      //  float sum = 0;
      //  int r = 0;
       // for(int i = 0;  i<4; i++)
      //  {
      //      sum += wheels[i].rpm;
     //           r++;
     //   }
     //   wheelsrpm = (r != 0) ? sum / r : 0;
   // }
    private void movevehicle()
    {
       
        //drivtype instead of putting all the power in all the wheels it will 
        if (drive == drivetype.allwheel)
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = IM.vertical * (totalpower / 4);

            }
        }
        else if (drive == drivetype.rearwheel)
        {
            for (int i = 2; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = IM.vertical * (totalpower / 2);
            }
        }
        else if (drive == drivetype.frontwheel)
        {
            for (int i = 0; i < wheels.Length - 2; i++)
            {
                wheels[i].motorTorque = IM.vertical * (totalpower / 2);
            }
        }
      //handbreak when pressing jump/spacebar : will break the the dift if used 
      

        KPH = rigid.velocity.magnitude * 3.6f;
        if (IM.ebreak)
      {
            wheels[3].brakeTorque = wheels[2].brakeTorque = breakpower;
        }
        else
        {
            wheels[3].brakeTorque = wheels[2].brakeTorque = 0;
        }
    }
    void steering()
    {
    if(IM.horizontonal > 0)
        {
            wheels[0].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (turnradius * (1.5f / 2))) * IM.horizontonal;
            wheels[1].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (turnradius - (1.5f / 2))) * IM.horizontonal;
        } else if(IM.horizontonal < 0)
        {
            wheels[0].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (turnradius - (1.5f / 2))) * IM.horizontonal;
            wheels[1].steerAngle = Mathf.Rad2Deg * Mathf.Atan(2.55f / (turnradius * (1.5f / 2))) * IM.horizontonal;
        } else
        {
            wheels[0].steerAngle = 0;
            wheels[1].steerAngle = 0;
        }
    }
    void animatewheels()    {
        Vector3 wheelposition = Vector3.zero;
        Quaternion wheelrottaion = Quaternion.identity;

        for (int i = 0; i < 4; i++)
        {
            wheels[i].GetWorldPose(out wheelposition, out wheelrottaion);
            wheelmesh[i].transform.position = wheelposition;
            wheelmesh[i].transform.rotation = wheelrottaion;
        }
    }
    private void getobjects()
    {
        IM = GetComponent<input_manager>();
        rigid = GetComponent<Rigidbody>();
    }
    private void adddownforce()
    {
        rigid.AddForce(-transform.up * downforce * rigid.velocity.magnitude);
    }

    private void getfriction()
    {
     for (int i = 0; i < wheels.Length; i++)
        {
            WheelHit wheelHit;
            wheels[i].GetGroundHit(out wheelHit);

            slip[i] = wheelHit.sidewaysSlip;
        }
    }
    private float driftFactor;
    private void drift()
    {
        float driftsmoothfactor = .7f * Time.deltaTime;

        if (IM.handbrake)
        {
            sidewaysfriction = wheels[0].sidewaysFriction;
            forwardfriction = wheels[0].forwardFriction;

            float velocity = 0;
            sidewaysfriction.extremumValue = sidewaysfriction.asymptoteValue = forwardfriction.extremumValue = forwardfriction.asymptoteValue =
                Mathf.SmoothDamp(forwardfriction.asymptoteValue, driftFactor * handbreakfrictionmultiplyer, ref velocity, driftsmoothfactor);

            for(int i = 0; i<4; i++)
            {
                wheels[i].sidewaysFriction = sidewaysfriction;
                wheels[i].forwardFriction = forwardfriction;
            }
            sidewaysfriction.extremumValue = sidewaysfriction.asymptoteValue = forwardfriction.extremumValue = forwardfriction.asymptoteValue = 1.1f;

            for(int i = 0; i <2; i++)
            {
                wheels[i].sidewaysFriction = sidewaysfriction;
                wheels[i].forwardFriction = forwardfriction;
            }
            rigid.AddForce(transform.forward * (KPH / 400) * 10000);
        }
        //when handbrake is being held
        else
        {
            sidewaysfriction = wheels[0].sidewaysFriction;
            forwardfriction = wheels[0].forwardFriction;

            forwardfriction.extremumValue = forwardfriction.asymptoteValue = sidewaysfriction.extremumValue = sidewaysfriction.asymptoteValue = ((KPH * handbreakfrictionmultiplyer) / 300) + 1;

            for (int i = 0; i < 4; i++)
            {
                wheels[i].sidewaysFriction = sidewaysfriction;
                wheels[i].forwardFriction = forwardfriction;
            }
        }

        for (int i = 2;i<4; i++)
        {
            WheelHit wheelHit;

            wheels[i].GetGroundHit(out wheelHit);

            if (wheelHit.sidewaysSlip < 0) driftFactor = (1 + -IM.horizontonal) * Mathf.Abs(wheelHit.sidewaysSlip);

            if (wheelHit.sidewaysSlip > 0) driftFactor = (1 + IM.horizontonal) * Mathf.Abs(wheelHit.sidewaysSlip);

        }
    }
    void adjustfriction()
    {
        if (IM.handbrake)
        {
            forwardfriction = wheels[0].forwardFriction;
            sidewaysfriction = wheels[0].sidewaysFriction;

            forwardfriction.extremumValue = forwardfriction.asymptoteValue * ((KPH * handbreakfrictionmultiplyer) / 300) + 1;
            sidewaysfriction.extremumValue = sidewaysfriction.asymptoteValue * ((KPH * handbreakfrictionmultiplyer) / 300) + 1;

            for (int i =0; i < 4; i++)
            {
                wheels[i].forwardFriction = forwardfriction;
                wheels[i].sidewaysFriction = sidewaysfriction;
            }

        }
        else if (IM.handbrake)
        {
            sidewaysfriction = wheels[0].sidewaysFriction;
            forwardfriction = wheels[0].forwardFriction;

            float velocity = 0;
            sidewaysfriction.extremumValue = sidewaysfriction.asymptoteValue = Mathf.SmoothDamp(sidewaysfriction.asymptoteValue, handbreakfriction, ref velocity, 0.05f * Time.deltaTime);
            forwardfriction.extremumValue = forwardfriction.asymptoteValue = Mathf.SmoothDamp(forwardfriction.asymptoteValue, handbreakfriction, ref velocity, 0.05f * Time.deltaTime);

            for(int i = 2; i<4; i++)
            {
                wheels[i].sidewaysFriction = sidewaysfriction;
                wheels[i].forwardFriction = forwardfriction;
            }

            sidewaysfriction.extremumValue = sidewaysfriction.asymptoteValue = 1.5f;
            forwardfriction.extremumValue = forwardfriction.asymptoteValue = 1.5f;

            for ( int i = 0; i < 2; i++ )
            {
                wheels[i].sidewaysFriction = sidewaysfriction;
                wheels[i].forwardFriction = forwardfriction;
            }
        }
       
    }
 
    void checkwheelspin()
    {
        float bind = 0.20f;
        {
         //   if(Input.GetKey(KeyCode.LeftShift))
              //  rigid.AddForce(transform.forward * 15000);
            if (IM.handbrake)
            {
                for (int i = 0; i < 4; i++)
                {
                    WheelHit wheelHit;
                    wheels[i].GetGroundHit(out wheelHit);
                    if(wheelHit.sidewaysSlip >bind || wheelHit.sidewaysSlip < -bind)
                    {
                       // applybooster(wheelHit.sidewaysSlip);
                    }
                }
            }
            for (int i = 2; i <4; i++)
            {
                WheelHit wheelHit;
                wheels[i].GetGroundHit(out wheelHit);

                if(wheelHit.sidewaysSlip < 0)                
                    tempo = (1 + -IM.horizontonal) * Mathf.Abs(wheelHit.sidewaysSlip * handbreakfrictionmultiplyer);
                    if (tempo < 0.5) tempo = 0.5f;

                if (wheelHit.sidewaysSlip > 0)
                    tempo = (1 + IM.horizontonal) * Mathf.Abs(wheelHit.sidewaysSlip * handbreakfrictionmultiplyer);
                if (tempo < 0.5) tempo = 0.5f;

                if (wheelHit.sidewaysSlip > .99f || wheelHit.sidewaysSlip < -.99f)
                {
                    float velocity = 0;
                    handbreakfriction = Mathf.SmoothDamp(handbreakfriction, tempo * 3, ref velocity, 0.1f * Time.deltaTime);
                }
                else handbreakfriction = tempo;

            }
        }
    }
}

