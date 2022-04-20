using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_mk2 : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 frontview;
    public Vector3 backview;
    public float followSpeed = 10;
    public float lookSpeed = 10;
    public void LookAtTarget()
{
    Vector3 _lookDirection = objectToFollow.position - transform.position;
    Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
    transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);
}

public void MoveToTarget()
{
        if (Input.GetKey(KeyCode.X))
        {
            Vector3 _targetPos = objectToFollow.position +
                               objectToFollow.forward * backview.z +
                               objectToFollow.right * backview.x +
                               objectToFollow.up * backview.y;
            transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed * Time.deltaTime);
        }
        else 
        {
            Vector3 _targetPos = objectToFollow.position +
                                 objectToFollow.forward * frontview.z +
                                 objectToFollow.right * frontview.x +
                                 objectToFollow.up * frontview.y;
            transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed * Time.deltaTime);
        }
  
}

private void FixedUpdate()
{
    LookAtTarget();
    MoveToTarget();
}


}