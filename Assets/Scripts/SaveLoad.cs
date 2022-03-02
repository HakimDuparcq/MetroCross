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
    public PlayerMovement PlayerMovement;
    public PlayerMovement GhostMovement;

    public bool recordTrue_moveghostFalse;


    public void Write()
    {
        string path = "Assets/Save/gamesave.txt";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(target.transform.position);
        writer.Close();

        path = "Assets/Save/gamesaveanim.txt";
        writer = new StreamWriter(path, true);
        string text = PlayerMovement.Animator.GetBool("Jump").ToString() + "," +
                        PlayerMovement.Animator.GetBool("Fall").ToString() + "," +
                        PlayerMovement.Animator.GetBool("Fly").ToString() + "," +
                        PlayerMovement.Animator.GetFloat("SpeedMove").ToString();

        writer.WriteLine(text);
        writer.Close();
    }



    public Vector3 Read(int nb_frame)
    {
        string path = "Assets/Save/gamesave.txt";
        StreamReader reader = new StreamReader(path);
        string text;
        Vector3 memo;

        
        for (int i = 0; i < 30000; i++)
        {
            text = reader.ReadLine();
            if (i==nb_frame && text!= null)
            {
                reader.Close();
                return StringToVector3(text);
            }
        }
        reader.Close();
        return new Vector3(-1, -1, -1);
    }


    public void ReadAnim(int nb_frame)
    {
        string path = "Assets/Save/gamesaveanim.txt";
        StreamReader reader = new StreamReader(path);
        string text;
        

        
        for (int i = 0; i < 5000; i++)
        {
            text = reader.ReadLine();
            if (i == nb_frame && text != null)
            {
                StringToAnimator(text);
            }
        }
        reader.Close();

    }
    public void StringToAnimator(string sVector)
    {
        // split the items
        string[] sArray = sVector.Split(',');


        


        GhostMovement.Animator.SetBool("Jump", bool.Parse(sArray[0]));
        GhostMovement.Animator.SetBool("Fall", bool.Parse(sArray[1]));
        GhostMovement.Animator.SetBool("Fly", bool.Parse(sArray[2]));
        GhostMovement.Animator.SetFloat("SpeedMove", float.Parse(sArray[3]));


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
        ReadAnim(nb_frame);
    }


    void Start()
    {

    }

    public void Update()
    {
        if (recordTrue_moveghostFalse)
        {
            Write();
        }
        else
        {
            MoveGhost();
        }


        nb_frame++;
    }
}
