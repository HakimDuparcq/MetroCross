using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{



    void Start()
    {
        
    }

    void Update()
    {
        
    }


    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.GetComponent<isSlowDown>())
        {
            if (other.GetComponent<isSlowDown>().isSlowDownObject)
            {
                //Debug.Log("SlowDown");
            }
            else
            {
               // Debug.Log("DONTSlowDown");
            }
        }
    }

}
