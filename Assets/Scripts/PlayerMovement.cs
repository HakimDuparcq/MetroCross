using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator Animator;
    public float Velocity;
    public Vector3 minSpeed;
    private bool isSlowDown;
    public bool groundedPlayer = false;
    public Rigidbody rb;
    void Start()
    {
        Animator.SetBool("Fall", false);
    }

    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(inputX * 1 ,0, inputZ * 4);
        //direction.Normalize();
        Vector3 realdirection = direction + minSpeed;
        

        if (isSlowDown)
        {
            realdirection = realdirection / 2;
        }

        Animator.SetBool("Jump", false);
        if (Input.GetKeyDown("space") && groundedPlayer && !Animator.GetCurrentAnimatorStateInfo(1).IsTag("JUMP"))
        {
            Animator.SetBool("Jump", true);
            if (!Animator.GetBool("Fall"))
            {
                rb.AddForce(new Vector3(0, 700, 0), ForceMode.Impulse);
            }
            //realdirection.y += 555;
        }


        
        if (!Animator.GetBool("Fall"))
        {
            rb.velocity = Vector3.Lerp(rb.velocity, realdirection, Time.deltaTime * 5f);
        }

        //float movementIntensity = realdirection.magnitude;
        float movementIntensity = realdirection.x- minSpeed.x;
        Animator.SetFloat("SpeedMove", movementIntensity, 0.1f, Time.deltaTime);

        

    }

  


    IEnumerator WaitToDisabled(float sec)
    {
        yield return new WaitForSeconds(sec);
        Animator.SetBool("Fall", false);
        Animator.SetBool("Fly", false);
    }


    public void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponent<isSlowDown>())
        {
            isSlowDown = other.GetComponent<isSlowDown>().isSlowDownObject;
        }

        if (other.name=="Fence(Clone)")
        {
            Animator.SetBool("Fall", true);
            StartCoroutine(WaitToDisabled(1.9f));
            //Debug.Log(other.name);
        }

        if (other.name== "Springboards(Clone)")
        {
            Animator.SetBool("Fly", true);
            //StartCoroutine(WaitToDisabled(5f));
            rb.AddForce(new Vector3(0, 2100, 0), ForceMode.Impulse);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name=="plane")
        {
            groundedPlayer = true;
            Animator.SetBool("Fly", false);

        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "plane")
        {
            groundedPlayer = false;
        }
    }


}
