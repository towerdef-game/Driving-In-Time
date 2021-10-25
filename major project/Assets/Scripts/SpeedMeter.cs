using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeedMeter : MonoBehaviour
{
    public Rigidbody targetCar;

    public float maxSpeedCar = 0.0f; // The maximum speed of the target ** IN KM/H **

    public float minSpeed;
    public float maxSpeed;
    public TextMeshProUGUI speedText;

    [Header("UI")]
    public RectTransform arrow; // The arrow in the speedometer

    private float speed = 0.0f;
    private void Update()
    {
        
        speed = targetCar.velocity.magnitude ;
       // Debug.Log(speed);
        if (speedText != null)
            speedText.text = ((int)speed) + " km/h";
        if (arrow != null)
            arrow.localEulerAngles =new Vector3(0, 0, Mathf.Lerp(minSpeed, maxSpeed, speed/160 )) ;
        //speed = Mathf.Clamp(speed, minSpeed, maxSpeed);
    }
}
