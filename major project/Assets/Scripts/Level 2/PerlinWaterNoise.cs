using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinWaterNoise : MonoBehaviour
{
    public float scale;
    public float waveSpeed;
    public float waveHeight;

    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        CalculateNoise();
    }

    void CalculateNoise()
    {
        MeshFilter mash = GetComponent<MeshFilter>();
        Vector3[] vibes = mash.mesh.vertices;

        for (int i = 0; i < vibes.Length; i++)
        {
            float pX = (vibes[i].x * scale) + (Time.time * waveSpeed);
            float pZ = (vibes[i].z * scale) + (Time.time * waveSpeed);

            vibes[i].y = Mathf.PerlinNoise(pX, pZ) * waveHeight;
        }

        mash.mesh.vertices = vibes;
        mash.mesh.RecalculateNormals();
        mash.mesh.RecalculateBounds();
    }
}
