using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{

    public bool objGrabbed;

    RaycastHit2D hit;

    public float distance = 2f;

    public Transform holdpoint;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

            if (!objGrabbed)
            {
                Physics2D.queriesStartInColliders = false;

                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.z, distance);
                
                if(hit.collider != null)
                {
                    objGrabbed = true;
                }

            }

            else
            {

            }

        }


        if(objGrabbed)
        {
            hit.collider.gameObject.transform.position = holdpoint.position;
        }
    }

    

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.z * distance);

    }
}
