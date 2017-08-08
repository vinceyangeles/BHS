using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public bool isGrounded = false;
    public Vector2 jumpVector;
    public Transform grounded;
    public float radius;
    public LayerMask ground;


    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * 8f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.right * 8f * Time.deltaTime);
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            GetComponent<Rigidbody2D>().AddForce(jumpVector, ForceMode2D.Force);
        }

        isGrounded = Physics2D.OverlapCircle(grounded.transform.position, radius, ground);
    }
}
