using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalinput;
    private float verticalinput;
    private float currentsteerangle;
    private float currentbreakforce;
    private bool isBreaking;

    [SerializeField] private float motorforce;
    [SerializeField] private float breakforce;
    [SerializeField] private float maxsteerangle;

    [SerializeField] private WheelCollider frontleftwheel;
    [SerializeField] private WheelCollider frontrightwheel;
    [SerializeField] private WheelCollider backleftwheel;
    [SerializeField] private WheelCollider backrightwheel;

    [SerializeField] private Transform frontleftwheeltransform;
    [SerializeField] private Transform frontrightwheeltransform;
    [SerializeField] private Transform backleftwheeltransform;
    [SerializeField] private Transform backrightwheeltransform;

    public Vector3 Try = new Vector3(0,-0.9f,0);
    public Rigidbody rig;
     void Start()
    {
        rig.centerOfMass = Try; 
    }
    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        Handlesteering();
        Updatewheels();
    }
    private void GetInput()
    {
        horizontalinput = Input.GetAxis(HORIZONTAL);
        verticalinput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }

    private void HandleMotor()
    {
        frontleftwheel.motorTorque = verticalinput * motorforce;
        frontrightwheel.motorTorque = verticalinput * motorforce;
        currentbreakforce = isBreaking ? breakforce : 0f;
         ApplyBreaking();
        
    }
    private void ApplyBreaking()
    {
        frontrightwheel.brakeTorque = currentbreakforce;
        frontleftwheel.brakeTorque = currentbreakforce;
        backrightwheel.brakeTorque = currentbreakforce;
        backleftwheel.brakeTorque = currentbreakforce;
    }
    private void Handlesteering()
    {
        currentsteerangle = maxsteerangle * horizontalinput;
        frontleftwheel.steerAngle = currentsteerangle;
        frontrightwheel.steerAngle = currentsteerangle;
    }
    private void Updatewheels()
    {
        updateSinglewheel(frontleftwheel, frontleftwheeltransform);
        updateSinglewheel(frontrightwheel, frontrightwheeltransform);
        updateSinglewheel(backleftwheel, backleftwheeltransform);
        updateSinglewheel(backrightwheel, backrightwheeltransform);
    }
    private void updateSinglewheel(WheelCollider wheelcollider, Transform wheeltransform)
    {
        Vector3 pos;
        Quaternion rot;
         wheelcollider.GetWorldPose(out pos, out rot);
        wheeltransform.rotation = rot;
        wheeltransform.position = pos;   
    }
}
