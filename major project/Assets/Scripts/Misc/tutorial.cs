using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorial : MonoBehaviour
{
    public GameObject[] popups;
   [HideInInspector]
    public int index;
    public GameObject phone;

    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
      for(int i =0; i < popups.Length; i++)
        {
            if(i == index)
            {
                popups[i].SetActive(true);
            }
            else
            {
                popups[i].SetActive(false);
            }
        }  
      if(index == 0)
        {
        //    if(Input.GetKeyDown("w") || Input.GetKeyDown("s"))
         //   {
           //     index++;
          //  }
        }
      if(index>= popups.Length)
        {
            index = 0;
        }
    }

    public void next()
    {
        index++;
    }
    public void back()
    {
        if (index > 0)
        {
            index--;
        }
    }
    public void quuit()
    {
        {
            phone.SetActive(false);
        }
    }
}
