using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishwasherUsefulObject : MonoBehaviour
{
    [SerializeField]private float spongeCapasiti;
    [SerializeField]private float spongeCarrentCapasiti;
    private DishwasherPointObjectScript dishwasherPointObjectScript;

    public float SpongeCarrentCapasiti { get { return spongeCarrentCapasiti; } }

    private void Start()
    {
        spongeCarrentCapasiti = spongeCapasiti;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            dishwasherPointObjectScript = other.GetComponent<DishwasherPointObjectScript>();
            float dirtCarrentCapasiti = dishwasherPointObjectScript.DirtCarrentCapasiti;
            if (spongeCarrentCapasiti > 0 && dirtCarrentCapasiti > 0)
            {
                spongeCarrentCapasiti -= 1f;
                dishwasherPointObjectScript.DirtCarrentCapasiti -= 1;

            }
            if (dirtCarrentCapasiti <= 1 && spongeCarrentCapasiti > 0)
            {
                Destroy(other.gameObject);
            }


        }
        Debug.Log(spongeCarrentCapasiti);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "SupplyObject"&& spongeCarrentCapasiti<spongeCapasiti)
        {
            spongeCarrentCapasiti+= 1f;
            Debug.Log(spongeCarrentCapasiti);
        }
    }


}
