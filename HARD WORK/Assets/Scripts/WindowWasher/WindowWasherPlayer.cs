using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowWasherPlayer : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float horizontalMax = 7.5f;
    [SerializeField] private float verticalMax = 8f;
    private bool cleaning;
    private float cleaningTime;
    [SerializeField] private float cleaningTimeBase;

    private CharacterController characterController;

    private Rigidbody2D playerRb;

    private ImputHandlerScript imputHandler;

    GameObject player;

    private void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        Cursor.lockState = CursorLockMode.Locked;
        imputHandler = ImputHandlerScript.Instance;
        player = this.gameObject;
        cleaningTime = cleaningTimeBase;
    }

    private void FixedUpdate()
    {
        
    }
    private void Update()
    {
        PlayerWindowWasher();

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
    private void PlayerWindowWasher()
    {

        Vector2 inputDirectionX = new Vector2(imputHandler.GetPlayerMove().x, 0);
        Vector2 inputDirectionY = new Vector2(0, imputHandler.GetPlayerMove().y);
        

        if (imputHandler.GetPlayerMove().x != 0 && !cleaning)
        {
            playerRb.MovePosition(playerRb.position + inputDirectionX * playerSpeed * 0.7f * Time.fixedDeltaTime);
            
        }
        else if (imputHandler.GetPlayerMove().y > 0 && !cleaning)
        {
            playerRb.MovePosition(playerRb.position + inputDirectionY * playerSpeed/2 * Time.fixedDeltaTime);
        }
        else if (imputHandler.GetPlayerMove().y < 0 && !cleaning)
        {
            playerRb.MovePosition(playerRb.position + inputDirectionY * playerSpeed*2 * Time.fixedDeltaTime);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.tag == "PointsObject" && imputHandler.GetInteraction() != 0 ) 
        {
            cleaning = true;
            Debug.Log(cleaningTime -= 1 * Time.deltaTime);
            cleaningTime -= 1 * Time.fixedDeltaTime;

            if (cleaningTime <= 0)
            {
                Destroy(other.gameObject);
                cleaning= false;
                cleaningTime = cleaningTimeBase;
            } 
        }
        else if (imputHandler.GetInteraction() == 0)
        {
            cleaning = false;
            cleaningTime = cleaningTimeBase;
        }

        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
