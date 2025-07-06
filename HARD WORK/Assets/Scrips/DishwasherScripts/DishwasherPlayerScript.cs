using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DishwasherPlayerScript : MonoBehaviour
{
    private ImputHandlerScript imputHandler;
    private bool spongeInHand;
    private Collider2D usefulObject;
    Vector2 diference;
    private float dirtDropsCount;
    private GameObject plate;

    [SerializeField] private UnityEvent spawnPlate;

    void Start()
    {
        imputHandler = ImputHandlerScript.Instance;
        plate = GameObject.FindGameObjectWithTag("PointsObject");
        plate.SetActive(false);
    }
    void Update()
    {
        diference = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = diference;
        dirtDropsCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }
    private void FixedUpdate()
    {
        if (spongeInHand && imputHandler.GetLMB() != 0)
        {
            usefulObject.transform.position = gameObject.transform.position;
        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "UsefulObject")
        {
            usefulObject = other;
            spongeInHand = true;
        }      
        if (other.tag == "Spawner" && imputHandler.GetLMB() != 0 && !spongeInHand && dirtDropsCount<=0 && plate.activeInHierarchy == false)
        {
            plate.SetActive(true);
            spawnPlate.Invoke();
        }
        if(other.tag == "PointsObject" && imputHandler.GetLMB() != 0 && !spongeInHand && dirtDropsCount <= 0)
        {
            plate.SetActive(false);
        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "UsefulObject")
        {
            spongeInHand = false;
        }
    }


    
}
