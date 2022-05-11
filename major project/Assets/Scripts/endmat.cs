using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endmat : MonoBehaviour
{
    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
       
     mat.SetFloat("_dispell", 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
