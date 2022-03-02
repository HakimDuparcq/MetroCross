using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class SaveLoad : MonoBehaviour
{
    public GameObject target;
    public GameObject ghost;

    private int nb_frame = 0;

    public void Write()
    {
        string path = "Assets/Save/gamesave.txt";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(target.transform.position);
        writer.Close();
    }



    public Vector3 Read(int nb_frame)
    {
        string path = "Assets/Save/gamesave.txt";
        StreamReader reader = new StreamReader(path);
        string text;
        Vector3 memo;

        text = reader.ReadLine();
        for (int i = 0; i < 30000; i++)
        {
            text = reader.ReadLine();
            if (i==nb_frame && text!= null)
            {
                //Debug.LogError(text);
                return StringToVector3(text);
            }
        }
       
        return new Vector3(-1, -1, -1);

    }

    

    public static Vector3 StringToVector3(string sVector)
    {
        // Remove the parentheses
        if (sVector.StartsWith("(") && sVector.EndsWith(")"))
        {
            sVector = sVector.Substring(1, sVector.Length - 2);
        }

        // split the items
        string[] sArray = sVector.Split(',');

        sArray[0] = sArray[0] +","+ sArray[1];
        sArray[1] = sArray[2] + "," + sArray[3];
        sArray[2] = sArray[4] + "," + sArray[5];

        //Debug.LogWarning(sArray[0]);

        // store as a Vector3
        Vector3 result = new Vector3(
            float.Parse(sArray[0]),
            float.Parse(sArray[1]),
            float.Parse(sArray[2]));

        return result;
    }


    public void MoveGhost()
    {
        ghost.transform.position = Read(nb_frame);

    }


    void Start()
    {

    }

    void Update()
    {
        //Write();
        MoveGhost();
        nb_frame++;

    }
}
