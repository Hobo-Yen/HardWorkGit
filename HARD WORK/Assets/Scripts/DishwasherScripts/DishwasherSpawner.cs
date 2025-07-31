using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishwasherSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] dirtDrops;
    [SerializeField] private Vector2 spawnPosition;
    // Start is called before the first frame update


    public void Spawn()
    {
        for (int i = 0; i < 25; i++)
            Instantiate(dirtDrops[Random.Range(0, dirtDrops.Length)], spawnPosition + Random.insideUnitCircle * 4.5f, Quaternion.identity);

    }
}
