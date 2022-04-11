using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class driftsmoke : MonoBehaviour
{
    public TrailRenderer[] tiremarks;
    public ParticleSystem[] smoke;
    private input_manager IM;
    public car_mk3 car;
    private bool smokeflag = false;
    private bool tiremarksflag = false;
    private void Start()
    {
        car = gameObject.GetComponent<car_mk3>();
        IM = gameObject.GetComponent<input_manager>();
    }

    private void FixedUpdate()
    {
        checkdrift();
        activatesmoke();
    }

    private void activatesmoke()
    {
        if (car.playpausesmoke) startsmoke(); else stopsmoke();

        if (smokeflag)
        {
            for (int i = 0; i < smoke.Length; i++)
            {
                var emission = smoke[i].emission;
                emission.rateOverTime = ((int)car.KPH * 2 <= 2000) ? (int)car.KPH * 2 : 2000;
                //  smoke[i].Play();
            }
        }
    }

    public void startsmoke()
    {
        if (smokeflag) return;
        for(int i = 0; i < smoke.Length; i++)
        {
            var emission = smoke[i].emission;
            emission.rateOverTime = ((int)car.KPH * 2 >= 2000) ? (int)car.KPH * 2 : 2000;
              smoke[i].Play();
        }
        smokeflag = true;
    }

    public void stopsmoke()
    {
        if (!smokeflag) return;
        for (int i = 0; i < smoke.Length; i++)
        {
            smoke[i].Stop();
        }
        smokeflag = false;
    }

    private void checkdrift()
    {
        if (IM.handbrake) startemitter();
        else stopemitter();
    }
    private void startemitter()
    {
        if (tiremarksflag) return;
        foreach( TrailRenderer t in tiremarks)
        {
            t.emitting = true;
        }
        tiremarksflag = true;
    }

    private void stopemitter()
    {
        if (!tiremarksflag) return;
        foreach (TrailRenderer t in tiremarks)
        {
            t.emitting = false;
        }
        tiremarksflag = false;
    }
}
