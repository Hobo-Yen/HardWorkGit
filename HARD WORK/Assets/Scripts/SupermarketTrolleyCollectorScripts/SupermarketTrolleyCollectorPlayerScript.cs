using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupermarketTrolleyCollectorPlayerScript : MonoBehaviour
{
    private Rigidbody2D playerRb;
    [SerializeField] float playerSpeed;
    [SerializeField] float playerRotationSpeed;
    private ImputHandlerScript imputHandler;
    [SerializeField] float maxVelocity;
    HingeJoint2D joint2D;

    void Start()
    {
        imputHandler = ImputHandlerScript.Instance;
        Cursor.lockState = CursorLockMode.Locked;
        playerRb = GetComponent<Rigidbody2D>();
        joint2D = GetComponent<HingeJoint2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMove();

    }

    private void PlayerMove()
    {
        Vector2 directionY = gameObject.transform.TransformDirection(Vector2.up)* imputHandler.GetPlayerMove().y;
        float playerRotation = playerRotationSpeed * imputHandler.GetPlayerMove().x;

        playerRb.MoveRotation(playerRb.rotation + playerRotation * -1 * Time.fixedDeltaTime);
        playerRb.MovePosition(playerRb.position + directionY * playerSpeed * Time.fixedDeltaTime);
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "UsefulObject") 
        {
            joint2D.connectedBody = collision.gameObject.GetComponentInParent<Rigidbody2D>();        
        }
    }
}
