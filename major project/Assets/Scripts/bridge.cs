using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridge : MonoBehaviour
{
  //  public  startposition;
  //  public  float endposition;
  //  public float rotatespeed;
   // public Vector3 start;
  //  public Vector3 end;
    public bool change = true;
    public Quaternion a;
    public Quaternion b;
    public float speed;
    // Start is called before the first frame update
   public void Start()
    {

      //  rotateup();
    }

    // Update is called once per frame
    public void Update()
    {
      //  transform.rotation = Quaternion.Slerp(a, b, speed * Time.deltaTime);
        if (change)
        {
            // transform.localEulerAngles = new Vector3(Mathf.PingPong(Time.time * rotatespeed, endposition), 0, 0);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, b, Time.deltaTime * speed);
        }
        else 
      //  if( change == false)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, a, Time.deltaTime * speed);
        }
      

    }

    public void rotateup()
    {
       
    }
}
