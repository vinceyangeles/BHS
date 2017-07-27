using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public bool grounded = false;
    public Transform groundedEnd;


	// Update is called once per frame
	void Update ()
    {
        Movement();
        Raycasting();
	}

    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * 8f * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
            transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.right * 8f * Time.deltaTime);
            transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500f);
        }
    }

    void Raycasting()
    {
        grounded = Physics2D.Linecast(this.transform.position, groundedEnd.position, 1 << LayerMask.NameToLayer("Ground"));
    }
}
