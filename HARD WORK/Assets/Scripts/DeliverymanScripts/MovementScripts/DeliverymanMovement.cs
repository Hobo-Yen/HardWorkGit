using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeliverymanMovement : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float horizontalMax = 7.5f;
    [SerializeField] private float verticalMax = 4.5f;
    private Rigidbody2D playerRb; 
    private ImputHandlerScript imputHandler;
    GameObject player;
    bool afterMove = true;

    private void Start()
    {
        
        playerRb = GetComponent<Rigidbody2D>();
        Cursor.lockState = CursorLockMode.Locked;
        imputHandler = ImputHandlerScript.Instance;
        player = this.gameObject;
    }

    private void FixedUpdate()
    {
       PlayerMoveDeliveryman();
    }
    private void Update()
    {

        if (player.transform.position.x > horizontalMax)
        {
            player.transform.position = new Vector2(horizontalMax, player.transform.position.y);
        }
        else if (player.transform.position.x < -horizontalMax)
        {
            player.transform.position = new Vector2(-horizontalMax, player.transform.position.y);
        }
        if (player.transform.position.y >= verticalMax)
        {
            player.transform.position = new Vector2(player.transform.position.x, verticalMax);
        }
        else if (player.transform.position.y <= -verticalMax)
        {
            player.transform.position = new Vector2(player.transform.position.x, -verticalMax);
        }
    }
    private void PlayerMoveDeliveryman()
    {
       
         Vector2 inputDirectionX = new Vector2(imputHandler.GetPlayerMove().x,0);
         Vector2 inputDirectionY = new Vector2(0,imputHandler.GetPlayerMove().y);

        if (imputHandler.GetPlayerMove().x == 0)
        {
            afterMove = true;
        }

        if (imputHandler.GetPlayerMove().x != 0 && afterMove)
        {
            playerRb.MovePosition(playerRb.position + inputDirectionX * playerSpeed/4);
            afterMove = false;           
        }
        else if (imputHandler.GetPlayerMove().y != 0)
        {
            playerRb.MovePosition(playerRb.position + inputDirectionY * playerSpeed * Time.fixedDeltaTime);
        }        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PointsObject")
        {
            Destroy(other.gameObject);
        }
        if(other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
