using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorConstraint : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.parent = gameObject.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            collision.transform.parent = null;
        }
    }
}
