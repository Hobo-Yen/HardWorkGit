using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishwasherPointObjectScript : MonoBehaviour
{
    [SerializeField] private float dirtCapasiti;
    [SerializeField] private float dirtCarrentCapasiti;

    public float DirtCarrentCapasiti { 
        get { return dirtCarrentCapasiti; }
        set { dirtCarrentCapasiti = value;}
    }
    private void Start()
    {
        dirtCarrentCapasiti = dirtCapasiti;
    }
    
}
