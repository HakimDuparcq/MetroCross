using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isSlowDown : MonoBehaviour
{
    public bool isSlowDownObject;
    public bool hasFence;
    public bool hasSpringboards;
    public Material white;
    public Material green;
    public GameObject Fence;
    public GameObject Springboard;


    [ContextMenu("Modificate cube")]
    public void ColorCUbe()
    {
        if (isSlowDownObject)
        {
            gameObject.GetComponent<MeshRenderer>().material = green;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = white;
        }


        if (hasFence)
        {
            GameObject FenceClone = Instantiate(Fence, new Vector3(gameObject.transform.position.x, (float)(gameObject.transform.position.y+ 1.2f), gameObject.transform.position.z), 
                Quaternion.identity, gameObject.transform);
            FenceClone.transform.localScale = new Vector3(1 / 1.5f, 1 / 1.5f, 1 / 1.5f);
        }
        else
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                if (gameObject.transform.GetChild(i) != null && gameObject.transform.GetChild(i)==Fence)
                {
                    DestroyImmediate(gameObject.transform.GetChild(i));
                }
            }
            
            
        }


        if (hasSpringboards)
        {
            GameObject SpringboardClone = Instantiate(Springboard, new Vector3(gameObject.transform.position.x, (float)(gameObject.transform.position.y ), gameObject.transform.position.z),
                Quaternion.identity, gameObject.transform);
            SpringboardClone.transform.localScale = new Vector3(1 / 1.5f, 1 / 1.5f, 1 / 1.5f);
        }
        else
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                if (gameObject.transform.GetChild(i) != null && gameObject.transform.GetChild(i) == Springboard)
                {
                    DestroyImmediate(gameObject.transform.GetChild(i));
                }
            }
        }
    }


}
