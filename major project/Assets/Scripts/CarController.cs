using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{


    public Rigidbody sphereRB;
    public Rigidbody carRB;

    private float moveInput;
    private float turninput;

    public float airDrag;
    private float grounddrag = 5f;

    private bool isgrounded;

    public float speed;
    public float reverseSPD;
    public float turnspeed;

    public float alignwithgroundspeed;

    public LayerMask groundlayer;
    
    void Start()
    {
        //detach sphere from car
        sphereRB.transform.parent = null;
          carRB.transform.parent = null;
        grounddrag = sphereRB.drag;

    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turninput = Input.GetAxisRaw("Horizontal");


        // false value if it greater then 0 its speed if its not its reverseSPD
        moveInput *= moveInput > 0 ? speed : reverseSPD;
        // makes the car object transform the sameas the sphere
        transform.position = sphereRB.transform.position;

        //rotate car left or right and doesn't move unles going forward or back
        float newrotation = turninput * turnspeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        transform.Rotate(0, newrotation, 0, Space.World);

        //reduces drag to give illusion of gravity this is basically a true or false statement
        sphereRB.drag = isgrounded ? grounddrag : airDrag;


        //raycast and align car to ground
        RaycastHit hit;
        isgrounded = Physics.Raycast(transform.position, -transform.up, out hit, 1f, groundlayer);
        Quaternion torotateto = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, torotateto, alignwithgroundspeed * Time.deltaTime);

    }
    private void FixedUpdate()
    {

        if (isgrounded)
        {
            sphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
        }
        else
        {
            sphereRB.AddForce(transform.up * -30f);
        }
          carRB.MoveRotation(transform.rotation);
    }
}
