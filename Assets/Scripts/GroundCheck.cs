using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField] private LayerMask platformMask;
    public bool isGrounded;

    private void OnTriggerStay2D(Collider2D collision)
    {
        isGrounded = (collision != null) && (((1 << collision.gameObject.layer) & platformMask) != 0);
        ////if (collision != null && collision.gameObject.layer == platformMask)
        //if(collision.gameObject.layer == platformMask)
        //    isGrounded = true;

        //Debug.Log("Entered Collision");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
        //Debug.Log("Exited Collision");
    }
}

