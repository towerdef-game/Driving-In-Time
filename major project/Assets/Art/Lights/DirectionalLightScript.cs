using System.Collections;
using UnityEngine;


public class DirectionalLightScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, Time.deltaTime * 400f, 0f)); 
    }
}
