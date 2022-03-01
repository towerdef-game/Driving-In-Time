using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroCameraswap : MonoBehaviour
{
    public Camera introCamera;
    public Camera carCamera;
    public car_mk3 car;
    public switchcamera switcher;
    public BezierCurveCamera bezierCurve;
    private bool finished = false;
    public GameObject firstPersonUi;
    // Start is called before the first frame update
    void Start()
    {
        introCamera.enabled = true;
        carCamera.enabled = false;
        firstPersonUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(bezierCurve.param >= 1 && !finished)
        {
            finished = true;
            SwapCameras();
        }
    }

    public void SwapCameras()
    {
        introCamera.enabled = false;
        carCamera.enabled = true;
        firstPersonUi.SetActive(true);
        car.enabled = true;
        switcher.enabled = true;
    }
}
