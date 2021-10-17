using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerascript : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float translateSpeed;
    [SerializeField] private float rotationspeed;

     void Update()
    {
        HandleTranslation();
        Handlerotation();

    }
    private void HandleTranslation()
    {
        var targetposition = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetposition, translateSpeed * Time.deltaTime);
    }
    private void Handlerotation()
    {
        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationspeed * Time.deltaTime);


    }

}
