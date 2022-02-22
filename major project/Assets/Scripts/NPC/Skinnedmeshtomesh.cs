using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class Skinnedmeshtomesh : MonoBehaviour
{
    public SkinnedMeshRenderer skinnedMesh;
    public VisualEffect vfx;
    public float refreshrate;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(updatevfx());
    }
    IEnumerator updatevfx()
    {
        while (gameObject.activeSelf)
        {
            Mesh m = new Mesh();
            skinnedMesh.BakeMesh(m);

            Vector3[] vertices = m.vertices;
            Mesh m2 = new Mesh();
            m2.vertices = vertices;

            vfx.SetMesh("mesh", m2);

            yield return new WaitForSeconds(refreshrate);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
