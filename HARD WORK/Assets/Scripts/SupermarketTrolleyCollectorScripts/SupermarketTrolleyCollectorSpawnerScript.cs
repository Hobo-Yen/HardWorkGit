using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SupermarketTrolleyCollectorSpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject trolley;
    [SerializeField] GameObject [] cars;
    [SerializeField] float[] vertical;
    [SerializeField] float[] horizontal;
    Vector2 parkingPlace;
    Vector2 [] parkingPlaces;
    int carrentParkingPlace;
    Queue <Vector2> activeParkingPlaceList = new Queue<Vector2>();
    [SerializeField] float maxPlacesCount;
    Vector2 randomPos;
    int randomPosNum;
    [SerializeField] float trolleyCount;
    private void Start()
    {
        parkingPlaces = new Vector2[vertical.Length * horizontal.Length];
        for (int t = 0; t < horizontal.Length; t++)
        {
            for (int j = 0; j < vertical.Length; j++)
            {
                parkingPlace = new Vector2(horizontal[t], vertical[j]);
                parkingPlaces[j + (t * vertical.Length)] = parkingPlace;

            }
        }
        CarsSpawn();
        TrolleySpawn();

    }

    void TrolleySpawn()
    {
        for (int i = 0; i < trolleyCount; i++)
        {
           
            randomPosNum = Random.Range(0, parkingPlaces.Length);
            if (activeParkingPlaceList.Contains(parkingPlaces[randomPosNum]))
            {
                i--;
            }
            else
            {
                activeParkingPlaceList.Enqueue(parkingPlaces[randomPosNum]);
                randomPos = parkingPlaces[randomPosNum] + new Vector2(0,Random.Range(-1,1));
                Instantiate(trolley, randomPos, Quaternion.Euler(0, 0, Random.Range(0f, 360f)));
            }                        
        }

    }
    void CarsSpawn()
    {
        for (int i = 0; i < maxPlacesCount; i++)
        {
            carrentParkingPlace = Random.Range(0, parkingPlaces.Length);
            if (activeParkingPlaceList.Contains(parkingPlaces[carrentParkingPlace]))
            {
                i--;
            }
            else
            {
                activeParkingPlaceList.Enqueue(parkingPlaces[carrentParkingPlace]);
            }
        }
        foreach (var item in activeParkingPlaceList)
        {
            Instantiate(cars[Random.Range(0,cars.Length)], item, transform.rotation);
        }
    }


}
