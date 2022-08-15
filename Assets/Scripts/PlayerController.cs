using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
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

    public static bool start;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        RotatingPlatform = false;
        Rotator = false;
        start = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (knockBackCounter <= 0)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);

            if(Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical") )
            {
                start = true;
            }

            if (RotatingPlatform)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed- (2 * direction), moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
            }

            if (Rotator)
            {
                moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y+5, Input.GetAxis("Vertical") * moveSpeed);
            }

            if (controller.isGrounded)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    moveDirection.y = jumpForce;
                }
            }
        } else
        {
            knockBackCounter -= Time.deltaTime;
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
        controller.Move(moveDirection * Time.deltaTime );

        anim.SetBool("isGrounded", controller.isGrounded);
        anim.SetFloat("Speed", (Mathf.Abs(Input.GetAxis("Vertical")) + Mathf.Abs(Input.GetAxis("Horizontal"))));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Platform")
        {
            RotatingPlatform = true;
            direction = 1;
        } else if (other.tag == "Platform2")
        {
            RotatingPlatform = true;
            direction = -1;
        }

        if (other.tag == "Rotator")
        {
            Rotator = true;            
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
    }


    public void KnockBack(Vector3 direction)
    {
        knockBackCounter = knockBackTime;
        moveDirection = direction * knockBackForce;
        moveDirection.y = knockBackForce;
    }

}
