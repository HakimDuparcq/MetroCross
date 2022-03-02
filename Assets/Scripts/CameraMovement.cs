using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    private Vector3 Offset;

    void Start()
    {
        Offset = gameObject.transform.position;
    }

    void Update()
    {
        gameObject.transform.position =  new Vector3( player.transform.position.x + Offset.x, 
                                        gameObject.transform.position.y, 
                                        gameObject.transform.position.z);



    }
}
