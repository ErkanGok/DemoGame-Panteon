using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class NPCController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;
    private Vector3 moveDirection;
    public float gravityScale;

    public Animator anim;

    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;

    private bool RotatingPlatform;
    private bool Rotator;

    private int direction;

    private bool alert;
    private bool alert2;
    private bool alert3;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        alert = false;
        alert2 = false;
        alert3 = false;
        RotatingPlatform = false;
        Rotator = false;
    }

    // Update is called once per frame
    void Update()
    {
       
            if (knockBackCounter <= 0)
            {
            if (PlayerController.start == true)
            {
                moveDirection = new Vector3(UnityEngine.Random.Range(-10, 10)*Time.deltaTime, moveDirection.y, moveSpeed);

                if (RotatingPlatform)
                {
                    moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed - (2 * direction), moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
                }

                if (Rotator)
                {
                    moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y + 5, Input.GetAxis("Vertical") * moveSpeed);
                }

                if (alert2) // sað taraf
                {
                    moveDirection += new Vector3(moveSpeed + 4, moveDirection.y, moveSpeed);
                }

                if (alert3) // sol taraf
                {
                    moveDirection -= new Vector3(moveSpeed - 4, moveDirection.y, moveSpeed);
                }

                if (controller.isGrounded)
                {
                    if (alert) // zýplama
                    {
                        moveDirection.y = jumpForce;
                    }
                }
           
            else
            {
                knockBackCounter -= Time.deltaTime;
            }
            }
            moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
            controller.Move(moveDirection * Time.deltaTime);

            anim.SetBool("isGrounded", controller.isGrounded);
            anim.SetFloat("Speed", (Mathf.Abs(moveSpeed) + Mathf.Abs(moveSpeed)));
            }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Platform")
        {
            RotatingPlatform = true;
            direction = 1;
        }
        else if (other.tag == "Platform2")
        {
            RotatingPlatform = true;
            direction = -1;
        }

        if (other.tag == "Rotator")
        {
            Rotator = true;
        }

        if (other.tag == "Alert")
        {
            alert = true;
        }

        if (other.tag == "Alert2")
        {
            alert2 = true;
        }

        if (other.tag == "Alert3")
        {
            alert3 = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Platform")
        {
            RotatingPlatform = false;
        }
        else if (other.tag == "Platform2")
        {
            RotatingPlatform = false;
        }

        if (other.tag == "Rotator")
        {
            Rotator = false;
        }

        if (other.tag == "Alert")
        {
            alert = false;
        }

        if (other.tag == "Alert2")
        {
            alert2 = false;
        }

        if (other.tag == "Alert3")
        {
            alert3 = false;
        }
    }


    public void KnockBack(Vector3 direction)
    {
        knockBackCounter = knockBackTime;
        moveDirection = direction * knockBackForce;
        moveDirection.y = knockBackForce;
    }

}
