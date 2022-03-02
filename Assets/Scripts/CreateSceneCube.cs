using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSceneCube : MonoBehaviour
{
    public GameObject cube;
    public Transform bottomleft;
    public Transform bottomright;
    public Transform topleft;
    public Transform topright;
    public GameObject Contener;

    public int length;
    public int width;

    private Vector3 position;

    [ContextMenu("Create cube")]
    public void CreateCubes()
    {
        //Destroy previous map
        foreach (Transform child in Contener.transform)
        {
            DestroyImmediate(child.gameObject);
        }


        //Create new map
        for (int y = 0;y < length; y++)
        {
            for (int x = 0;x < width; x++)
            {
                position = bottomright.position + new Vector3(0, 0, 1.5f) * x  + new Vector3(y*1.5f,0,0);
                Instantiate(cube, position, Quaternion.identity, Contener.transform);
            }
        }
        
    }
    
}
