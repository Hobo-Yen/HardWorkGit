using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverymanSpawnerScript : MonoBehaviour
{
    [SerializeField] GameObject[] deliverymanEnemies;
    [SerializeField] GameObject deliveryPlace;  
    [SerializeField] float[] roadsPoints;
    float enemyRoadPoint;
    float deliveryRoadPoint;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
        StartCoroutine(DeilveryPlaceSpawn());
    }

    private IEnumerator EnemySpawn()
    {

        while (Time.timeScale == 1)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 0.7f));
            enemyRoadPoint = roadsPoints[Random.Range(0, roadsPoints.Length)];
            if (enemyRoadPoint > 0) 
            {
                Instantiate(deliverymanEnemies[Random.Range(0, deliverymanEnemies.Length - 1)], new Vector2(enemyRoadPoint, -5.5f), transform.rotation);
            }
            else
            {
                Instantiate(deliverymanEnemies[Random.Range(0, deliverymanEnemies.Length - 1)], new Vector2(enemyRoadPoint, 5.5f), transform.rotation);
            }         
           
        }
    }
    private IEnumerator DeilveryPlaceSpawn()
    {

        while (Time.timeScale == 1)
        {
            yield return new WaitForSeconds(10);
            deliveryRoadPoint = Random.value < 0.5f ? roadsPoints[0] : roadsPoints[3];
            Instantiate(deliveryPlace, new Vector2(deliveryRoadPoint, 5.5f), transform.rotation);
        }

    }

}
