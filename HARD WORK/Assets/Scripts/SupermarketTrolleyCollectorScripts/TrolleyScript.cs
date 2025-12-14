using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrolleyScript : MonoBehaviour
{
    HingeJoint2D joint2D;
    void Start()
    {
        joint2D = GetComponent<HingeJoint2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "UsefulObject")
        {
            joint2D.connectedBody = collision.gameObject.GetComponentInParent<Rigidbody2D>();
        }
    }
}
