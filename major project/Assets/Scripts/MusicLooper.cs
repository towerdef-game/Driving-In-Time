using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class MusicLooper : MonoBehaviour
{
    public StudioEventEmitter music;
    public bool isMusicplaying;

    // Update is called once per frame
    void Update()
    {

        if (!music.IsPlaying())
        {
            music.SetParameter("hasWormed", 1);
            music.Play();
            Debug.Log("sugma");
        }

        if (!music.IsPlaying())
        {
            isMusicplaying = false;
        }

        if (music.IsPlaying())
        {
            isMusicplaying = true;
        }
    }
}
