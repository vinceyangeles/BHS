using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AeroMovement : MonoBehaviour {

    //Walking Animation
    public float speed = 5f;
    Animator anim;

    //Jump Functions
    public bool isGrounded = false;
    public Vector2 jumpVector;
    public Transform grounded;
    public float radius;
    public LayerMask ground;

    // Use this for initialization
    void Start ()
    {
		anim = GetComponent<Animator>();
	}
	
	void Update ()
    {

        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("Moving", true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
            transform.eulerAngles = new Vector2(0, 360);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Moving", true);
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
            transform.eulerAngles = new Vector2(0, 0);
        }

        else
        {
            anim.SetBool("Moving", false);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            GetComponent<Rigidbody2D>().AddForce(jumpVector, ForceMode2D.Force);
        anim.SetBool("Grounded", true);
        anim.SetFloat("velocityY", GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            anim.SetBool("Grounded", false);
        }

        isGrounded = Physics2D.OverlapCircle(grounded.transform.position, radius, ground);
    }
}
