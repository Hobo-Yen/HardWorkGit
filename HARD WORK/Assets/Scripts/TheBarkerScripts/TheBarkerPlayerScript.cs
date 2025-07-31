using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheBarkerPlayerScript : MonoBehaviour
{
    private ImputHandlerScript imputHandler;
    private ArrowScript arrowScript;
    private bool buttonsHold;

    void Start()
    {
        imputHandler = ImputHandlerScript.Instance;
        buttonsHold = true;
    }

    private void Update()
    {


       



    }

    private void OnTriggerStay2D(Collider2D over)
    {
        if (over.tag == "PointsObject") 
        {
            if (imputHandler.GetPlayerMove().x == 0 && imputHandler.GetPlayerMove().y == 0)
            {

                buttonsHold = false;
            }
            arrowScript = over.GetComponent<ArrowScript>();
            if (arrowScript.ArowDirection == ArrowScript.Arrows.ArrowUp && imputHandler.GetPlayerMove().y > 0 && buttonsHold == false)
            {
                Destroy(over.gameObject);
                buttonsHold=true;
            }
            else if (arrowScript.ArowDirection == ArrowScript.Arrows.ArrowDown && imputHandler.GetPlayerMove().y < 0 && buttonsHold == false)
            {
                Destroy(over.gameObject);
                buttonsHold = true;
            }
            else if (arrowScript.ArowDirection == ArrowScript.Arrows.ArrowLeft && imputHandler.GetPlayerMove().x < 0 && buttonsHold == false)
            {
                Destroy(over.gameObject);
                buttonsHold = true;
            }
            else if (arrowScript.ArowDirection == ArrowScript.Arrows.ArrowRight && imputHandler.GetPlayerMove().x > 0 && buttonsHold == false)
            {
                Destroy(over.gameObject);
                buttonsHold = true;
            }
        }
    }
}
